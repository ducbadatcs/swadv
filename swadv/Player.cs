using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swadv
{
    public class Player : GameObject
    {
        private Inventory _inventory = new Inventory();

        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc) { }

        public GameObject Locate(string id)
        {
            return this._inventory.Fetch(id);
        }

        public override string LongDescription 
        {
            get 
            {
                return
                    "You are " + this.Name + " " + this.ShortDescription + "\n" +
                    "You are carrying" + this._inventory.ItemList;
            }
        }
    }
}
