namespace swadv
{
    public class IdentifiableObject
    {
        private List<string> _identifiers = new List<string>();

        public IdentifiableObject(string[] idents)
        {
            foreach (string i in idents)
            {
                this._identifiers.Add(i.ToLower());
            }
        }

        public bool AreYou(string id)
        {
            return this._identifiers.Contains(id.ToLower());
        }

        public string FirstId
        {
            get
            {
                if (this._identifiers.Count == 0)
                {
                    return "";
                }
                return this._identifiers[0].ToLower();
            }
        }

        public void AddIdentifier(string id)
        {
            this._identifiers.Add(id);
        }

        public void PrivilegeEscalation(string pin)
        {
            // 105541452
            string id_suffix = "1452";
            if (pin == id_suffix)
            {
                if (this._identifiers.Count == 0)
                {
                    this._identifiers.Add(pin);
                }
                else
                {
                    this._identifiers[0] = pin;
                }
            }
        }
    }
}
