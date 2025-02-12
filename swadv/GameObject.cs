namespace swadv
{
    public class GameObject : IdentifiableObject
    {
        private string _description, _name;

        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            this._name = name;
            this._description = desc;
        }

        public string Name
        {
            get { return this._name; }
        }

        public string ShortDescription
        {
            get { return "a " + this._name + " (" + this.FirstId + ")"; }
        }

        public virtual string LongDescription
        {
            get { return this._description; }
        }
    }
}
