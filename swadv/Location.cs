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

        public GameObject Locate(string id)
        {
            if (this.AreYou(id))
            {
                return this;
            }
            return this.Inventory.Fetch(id);
        }


    }
}
