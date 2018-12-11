using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfUI
{
    public class Month
    {
        public string MonthName { get; set; }
        public string Payment { get; set; }

        public Month(string monthname)
        {
            MonthName = monthname;
        }

       
    }
}
