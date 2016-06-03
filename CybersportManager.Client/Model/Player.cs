using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CybersportManager.Client
{
    public class Player : Base<Player>
    {
        public string SecondName { get; set; }
        public string NickName { get; set; }
        public int Age { get; set; }
        public Role Role { get; set; }
        public RoleType RoleType {get;set;}
        public Team Team { get; set; }
        public BitmapImage Img { get; set; }
        public bool Teamless { get; set; }
        public Country Homeland { get; set; }
           
        public Player(string name, string secondname, string nick, int age, RoleType roletype) : base(name)
        {
            this.SecondName = secondname;
            this.NickName = nick;
            this.Age = age;
            this.RoleType = roletype;
        }

        public List<string> fieldsToList()
        {
            List<string> datalist = new List<string>();
            datalist.Add(Name);
            datalist.Add(SecondName);
            datalist.Add(NickName);
            datalist.Add(Age.ToString());
            datalist.Add(RoleType.ToString());
            if (!Teamless)
            { datalist.Add(Team.Name); }
            else
            { datalist.Add("None"); }
            datalist.Add(Homeland.Name);
            datalist.Add(Img.UriSource.ToString());
            return datalist;
        }

    }
}
