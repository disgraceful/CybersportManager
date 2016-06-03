using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CybersportManager.Client
{
    public class Country : Base<Country>
    {
        public string CountryImg { get; set; }

        public Country(string imgpath, string name) : base(name)
        {
            this.CountryImg = imgpath;
        }


    }
}
