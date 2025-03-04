namespace swadv
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory = new Inventory();
        private Location _location = new Location(new string[] { }, "", "");

        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc) { }

        public GameObject Locate(string id)
        {
            id = id.ToLower();
            if (id == "me" || id == "inventory") return this;
            GameObject inventoryFetch = this._inventory.Fetch(id);
            if (inventoryFetch is not null)
            {
                return inventoryFetch;
            }
            GameObject locationFetch = this.Location.Locate(id);
            if (locationFetch is not null)
            {
                return locationFetch;
            }
            return null;
        }

        public override string FullDescription
        {
            get
            {
                return
                    "You are " + this.Name + " " + this.ShortDescription + "\n" +
                    "You are carrying" + this._inventory.ItemList;
            }
        }

        public Inventory Inventory
        {
            get { return this._inventory; }
        }

        public Location Location 
        { 
            get { return this._location; } 
            set { this._location = value; }
        }
    }
}
