namespace swadv
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" }) { }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length != 3 && text.Length != 5)
            {
                return "I don't know how to look like that";
            }
            if (text[0] != "look")
            {
                return "Error in look input";
            }
            if (text[1] != "at")
            {
                return "What do you want to look at?";
            }
            if (text.Length == 5 && text[3] != "in")
            {
                return "What do you want to look in?";
            }
            // now that we covered all extra cases
            //GameObject obj;
            IHaveInventory container = null;

            // container
            if (text.Length == 3)
            {
                container = p;
            }
            else if (text.Length == 5)
            {
                container = this.FetchContainer(p, text[4]);
            }
            string item_id = text[2];
            return this.LookAtIn(item_id, container);
        }

        public IHaveInventory FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }

        public string LookAtIn(string thingId, IHaveInventory container)
        {
            return container.Locate(thingId).Name;
        }
    }
}
