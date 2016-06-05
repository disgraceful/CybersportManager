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
        public List<RoleType> HeroRoles { get; set;}

        public List<Player> Playerlist => Base<Role>.Items.Values.Where(x => x.Hero == this).Select(x => x.Player).ToList();

        public Hero(string name, string sname,List<RoleType>roles,string imgpath):base(name)
        {
            SecondaryName = sname;
            HeroRoles = roles;
            Imgpath = imgpath;
        }
    }
}
