using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersportManager.Client
{
    public class Team:Base<Team>
    {
        public string TeamTag { get; set; }
        public Region TeamRegion { get; set; }
        public string Imgpath { get; set; }

        public List<Player> CurRoster
        {
            get { return Base<Player>.Items.Values.Where(x => x.Team == this).ToList(); }
        }
     
        public List<Tournament> Participations => Base<TournamentTeam>.Items.Values.Where(x => x.Team == this).Select(x => x.Tournament).ToList();
     
        public Team(string name, string teamtag, Region region) : base(name)
        {
            this.TeamTag = teamtag;
            this.TeamRegion = region;
        }

        public SignPlayer()
        {

        }

        public List<string> fieldsToList()
        {
            List<string> datalist = new List<string>();
            datalist.Add(Name);
            datalist.Add(TeamTag);
            datalist.Add(TeamRegion.ToString());
            return datalist;
        }       
    }
    public enum Region
    {
        Europe,Asia,NorthAmerica
    };
}
