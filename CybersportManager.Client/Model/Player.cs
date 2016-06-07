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
        public BitmapImage Img { get; set; }
        public string Homeland { get; set; }
        public bool Teamless => _teamid != null ? true : false;

        private Guid _teamid;

        public Team Team
        {
            get {
                if (!Teamless)
                    return Base<Team>.Items[_teamid];
                else
                    return null;
            }
        }

        public string TeamName
        {
            get { if (!Teamless)
                {
                    return Base<Team>.Items[_teamid].Name;

                }
                else
                    return "-";
            }
    
        }
        public RoleType RoleType {get;set;}

        public List<Hero> Herolist => Base<Role>.Items.Values.Where(x => x.Player == this).Select(x => x.Hero).ToList();

        public void SetTeam(Team t)
        {
            _teamid = t.Id;
        }

        public Player(string name, string secondname, string nick, int age, RoleType roletype) : base(name)
        {
            SecondName = secondname;
            NickName = nick;
            Age = age;
            RoleType = roletype;
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
            datalist.Add(Homeland);
            datalist.Add(Img.UriSource.ToString());
            return datalist;
        }

    }
}
