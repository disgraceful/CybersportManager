using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersportManager.Client
{
    public class Hero:Base<Hero>
    {
        public string SecondaryName { get; set; }
        public string Imgpath { get; set; }
        public List<RoleType> roles = new List<RoleType>();
        public List<RoleType> HeroRoles
        {
            get { return roles; }
            set { roles = value; }
        }

        public Hero(string name, string sname,List<RoleType>roles,string imgpath):base(name)
        {
            SecondaryName = sname;
            HeroRoles = roles;
            Imgpath = imgpath;
        }
    }
}
