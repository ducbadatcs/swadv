namespace swadv
{
    public interface IHaveInventory
    {
        public GameObject Locate(string id);

        public String Name { get; }
    }
}
