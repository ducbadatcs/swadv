namespace swadv
{
    public class Player : GameObject
    {
        private Inventory _inventory = new Inventory();

        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc) { }

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
                return
                    "You are " + this.Name + " " + this.ShortDescription + "\n" +
                    "You are carrying" + this._inventory.ItemList;
            }
        }

        public Inventory Inventory
        {
            get { return this._inventory; }
        }
    }
}
