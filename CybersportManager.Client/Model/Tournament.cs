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
        public List<Team> Invited { get; set; }

        public Tournament(string name, int prizepool,Region CurrentRegion) : base(name)
        { }

    }
}
