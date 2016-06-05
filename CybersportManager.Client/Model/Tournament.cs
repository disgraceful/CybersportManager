using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersportManager.Client
{
    public class Tournament:Base<Tournament>
    {
        public Region CurrentRegion { get; set; }
        public int Prizepool { get; set; }
        public List<Team> Invited => Base<TournamentTeam>.Items.Values.Where(x => x.Tournament == this).Select(x => x.Team).ToList();

        public Tournament(string name, int prizepool,Region CurrentRegion) : base(name)
        { }

    }
}
