using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swadv
{
    // identifiable and  have a name + desc -> GameObject
    // Contain Items => IHaveInventory
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory = new Inventory();
        private List<Path> _paths = new List<Path>();

        public Location(string [] ids, string name, string desc) : base(ids, name, desc)
        {
        }

        public Inventory Inventory
        {
            get
            {
                return this._inventory;
            }
        }

        public List<Path> paths
        {
            get
            {
                return this._paths;
            }
        }

        public void AddPathTo(string[] direction, Location destination)
        {
            this._paths.Add(new Path(direction, "", "", this, destination));
        }

        public Path GetPath(string identifier)
        {
            foreach (Path path in this._paths)
            {
                if (path.AreYou(identifier))
                {
                    return path;
                }
            }
            return null;
        }

        public GameObject Locate(string id)
        {
            if (this.AreYou(id))
            {
                return this;
            }
            return this.Inventory.Fetch(id);
        }

        public string AllPaths
        {
            get
            {
                string x = "";
                foreach (Path path in this._paths)
                { 
                    x += $"Head {path.FirstId} to {path.destination.Name}\n"; 
                }
                return x;
            }
        }
    }
}
