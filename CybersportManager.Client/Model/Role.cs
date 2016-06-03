using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersportManager.Client
{
    public class Role
    {
        public Player _Player { get; set; }
        public Hero _Hero { get; set; }

    }

    public enum RoleType
    {
        Top,Mid,Support,Jungle,Carry
    };
}
