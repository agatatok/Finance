using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WpfUI
{
    class Analizer
    {
        private string source;
        private string[] text;
        public string Source { get => source; set => source = value; }

        public Analizer(string source)
        {
            this.source = source;
        }

        
        public void Analize()
        {
            Read();
            Payment[] payments = new Payment[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                string[] oneLine = text[i].Split('|');
                double sumDouble = Convert(oneLine[5]);
                if (sumDouble > 0)
                {
                    payments[i] = new Payment(oneLine[3], oneLine[2], Convert(oneLine[5]));
                }
            }

        }


        private double Convert(string sum)
        {
            if (sum.StartsWith("-"))
            {
                return 0;
            }
            else
            {
                sum = sum.Replace(',', '.');
                return Double.Parse(sum, System.Globalization.CultureInfo.InvariantCulture);
            }
        }


        private void Read()
        {
            int linesCount = 0;
            using (StreamReader sr = new StreamReader(source))
            {
                while (sr.ReadLine() != null) { linesCount++; }
            }

            text = new string[linesCount - 1];

            using (StreamReader sr = new StreamReader(source))
            {
                sr.ReadLine();
                for (int i = 0; i < text.Length; i++)
                {
                    text[i] = sr.ReadLine();
                }
            }
        }

        
    }
}
