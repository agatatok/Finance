using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace WpfUI
{
    class Analizer
    {
        private string source;
        private ArrayList textarray;
        public string Source { get => source; set => source = value; }

        public Analizer(string source)
        {
            this.source = source;
            textarray = new ArrayList();
        }

        
        public void Analize()
        {
            Read();
            ArrayList paymentlist = new ArrayList();
            for (int i = 0; i < textarray.Count-1; i++)
            {
                string[] oneLine = textarray[i].ToString().Split('|');
                double sumDouble = ConvertSum(oneLine[5]);
                if (sumDouble > 0)
                {
                    paymentlist.Add(new Payment(oneLine[3], oneLine[2], ConvertSum(oneLine[5])));
                }
            }

        }


        private double ConvertSum(string sum)
        {
            if (sum.StartsWith("-"))   { return 0; }
            else
            {
                sum = sum.Replace(',', '.');
                return Double.Parse(sum, System.Globalization.CultureInfo.InvariantCulture);
            }
        }


        private void Read()
        {
            using (StreamReader sr = new StreamReader(source))
            {
                //reading lines from second to last, removing null at the and
                string line = sr.ReadLine();
                while (line != null)
                {
                    line = sr.ReadLine();
                    textarray.Add(line);
                }
                textarray.RemoveAt(textarray.Count-1);
                
            }
        }
    }
}
