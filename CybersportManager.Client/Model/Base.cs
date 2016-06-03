using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersportManager.Client
{
    public class Base<T> where T : Base<T>
    {
        static public Dictionary<Guid, T> Items = new Dictionary<Guid, T>();

        public Guid Id { get; private set; }
        public string Name { get; set; }

        public Base() { }
        public Base(string name)
        {
           Id = Guid.NewGuid();
           Items.Add(Id, (T)this);
           Name = name;
        }

        //public override string ToString()
        //{
        //    return Name;
        //}
    }
}
