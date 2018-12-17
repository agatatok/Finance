using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfUI
{
    class Payment
    {
        private string name;
        private string title;
        private double sum;


        public string Name { get => name; set => name = value; }
        public double Sum { get => sum; set => sum = value; }
        public string Title { get => title; set => title = value; }

        public Payment(string name, string title, double sum)
        {
            this.name = name;
            this.title = title;
            this.sum = sum;
        }
    }
}
