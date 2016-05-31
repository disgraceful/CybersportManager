using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Player : Base<Player>
    {
        public string SecondName { get; set; }
        public string NickName { get; set; }
        public int Age { get; set; }
        public Role Role { get; set; }
        public RoleType RoleType {get;set;}
        public Team Team { get; set; }
        public string Imgpath { get; set; }
        public bool Teamless { get; set; }
        public Country Homeland { get; set; }

           
        public Player(string name, string secondname, string nick, int age, RoleType roletype) : base(name)
        {
            this.SecondName = secondname;
            this.NickName = nick;
            this.RoleType = roletype;
        }
      

    }
}
