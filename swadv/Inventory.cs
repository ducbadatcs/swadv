using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swadv
{
    public class Inventory : Item
    {
        private List<Item> _items = new List<Item>();

        public Inventory() : base(new string[] { }, "", "") { }

        public bool HasString(string id)
        {
            foreach (Item item in this._items)
            {
                if (item.AreYou(id))
                {
                    return true;
                }
            }
            return false;
        }

        public void Put(Item itm)
        {
            this._items.Add(itm);
        }

        public void Take(string id)
        {
            foreach (Item item in this._items)
            {
                if (item.AreYou(id))
                {
                    this._items.Remove(item);
                }
            }
        }

        public Item Fetch(string id)
        {
            foreach (Item item in this._items)
            {
                if (item.AreYou(id))
                {
                    return item;
                }
            }
            // "sẽ return null em nhé" - thầy Khoa 
            // =)))))))))))))
            return null;
        }

        public string ItemList
        {
            get
            {
                string list = "\n";
                foreach (Item item in this._items)
                {
                    list += "\t" + item.ShortDescription + "\n";
                }
                return list;
            }
        }
    }
}

