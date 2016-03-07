using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Testing
{
    public class Expenditure
    {
        public Expenditure()
        {
            Date = "";
            Title = "";
            Cost = 0;
        }
        public Expenditure(string d, string t, float c)
        {
            Date = d;
            Title = t;
            Cost = c;            
        }
        private string date;
        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private float cost;
        public float Cost
        {
            get { return cost; }
            set { cost = value; }
        }
    }
}
