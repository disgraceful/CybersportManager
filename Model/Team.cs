using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Team:Base<Player>
    {
        public List<Player> curroster = new List<Player>();
        public List<Player>CurRoster { get; set; }
        public List<Player> subs = new List<Player>();
        public List<Player> Subs { get; set; }

        public string TeamTag { get; set; }
        public Region TeamRegion { get; set; }
        public string Imgpath { get; set; }

        public Team(string name,string teamtag) : base(name) { }
        public Team(string name,string teamtag,Region region) : base(name) { }
        public Team(string name, string teamtag, List<Player>roster, Region region) : base(name) { }
    }
    public enum Region
    {
        Europe,Asia,NorthAmerica
    };
}
