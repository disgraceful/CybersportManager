using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersportManager.Client
{
    public class TournamentTeam : Base<TournamentTeam>
    {
        private Guid _tournamentid;
        private Guid _teamid;

        public Tournament Tournament
        {
            get { return Base<Tournament>.Items[_tournamentid]; }
            set { _tournamentid = value.Id; }
        }

        public Team Team
        {
            get { return Base<Team>.Items[_teamid]; }
            set { _teamid = value.Id; }
        }

        public TournamentTeam(Team team, Tournament tour)
        {
            _tournamentid = team.Id;
            _teamid = tour.Id;
        }
    }
}
