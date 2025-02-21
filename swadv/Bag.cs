namespace swadv
{
    public class Bag : Item, IHaveInventory
    {
        private Inventory _inventory = new Inventory();
        public Bag(string[] ids, string name, string desc) : base(ids, name, desc)
        { }

        public GameObject Locate(string id)
        {
            if (this.AreYou(id))
            {
                return this;
            }
            return this._inventory.Fetch(id);
        }

        public override string FullDescription
        {
            get
            {
                return "In the " + this.Name + " you can see:" + this._inventory.ItemList;
            }
        }

        public Inventory Inventory
        {
            // makes perfect sense 
            get { return this._inventory; }
        }
    }
}
