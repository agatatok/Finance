using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfUI
{
    public class Person
    {
        private string nazwisko;
        private string imię;
        private string eMail;
        private int nrtel;
        private double opłatawpisowa;


        public Month[] listMonths;
        
        public string Nazwisko { get { return nazwisko; } set { nazwisko = value; } }
        public string Imię { get { return imię; } set { imię = value; } }
        public string Email { get { return eMail; } set { eMail = value; } }
        public int Nrtel { get { return nrtel; } set { nrtel = value; } }
        public double OpłataWpisowa { get { return opłatawpisowa; } set { opłatawpisowa = value; } }
        
                     
        public void FullFillMonths(int pierwszyMiesiac)
        {
            Month[] monthlist = new Month[10];
            monthlist[0] = new Month("Wrzesień");
            monthlist[1] = new Month("Październik");
            monthlist[2] = new Month("Listopad");
            monthlist[3] = new Month("Grudzień");
            monthlist[4] = new Month("Styczeń");
            monthlist[5] = new Month("Luty");
            monthlist[6] = new Month("Marzec");
            monthlist[7] = new Month("Kwiecień");
            monthlist[8] = new Month("Maj");
            monthlist[9] = new Month("Czerwiec");

            for (int i = 0; i < monthlist.Length; i++)
            {
                if (i == pierwszyMiesiac)
                {
                    break;
                }
                else
                {
                    monthlist[i].Payment = "-";
                }
            }
            listMonths = monthlist;
            
        }

        public string Nazwa => $"{Nazwisko} {Imię}";
    }
}
