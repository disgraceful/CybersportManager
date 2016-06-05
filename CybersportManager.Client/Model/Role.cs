using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersportManager.Client
{
    public class Role:Base<Role>
    {
        private Guid _playerid;
        private Guid _heroid;

        public Player Player
        {
            get { return Base<Player>.Items[_playerid]; }
            set { _playerid = value.Id; }
        }

        public Hero Hero
        {
            get { return Base<Hero>.Items[_heroid]; }
            set { _heroid = value.Id; }
        }

        public Role(Player p, Hero h)
        {
            _playerid = p.Id;
            _heroid = h.Id;
        }
    }




    public enum RoleType
    {
        Top, Mid, Support, Jungle, Carry
    };
}
