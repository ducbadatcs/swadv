namespace swadv
{
    public class Inventory : GameObject
    {
        private List<Item> _items;

        public Inventory() : base(new string[] { }, "", "")
        {
            this._items = new List<Item>();
        }

        public bool HasItem(string id)
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
            Item to_be_removed = null;
            foreach (Item item in this._items)
            {
                if (item.AreYou(id))
                {
                    to_be_removed = item;
                    break;
                }
            }
            if (to_be_removed is not null)
            {
                this._items.Remove(to_be_removed);
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

