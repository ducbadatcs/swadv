using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swadv
{
    public class Path : GameObject
    {
        public Location origin, destination;
        public Path(string[] ids, string name, string desc, Location origin, Location destination) : base(ids, name, desc)
        {
            this.origin = origin;
            this.destination = destination;
        }

        public void MovePlayer(ref Player p)
        {
            if (p is null || p.Location != this.origin)
            {
                throw new Exception("Player is null or not in origin");
            }
            p.Location = this.destination;
        }
    }
}
