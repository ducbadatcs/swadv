namespace swadv
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" }) { }

        public override string Execute(ref Player p, string[] text)
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
                string containerId = text[4];
                container = this.FetchContainer(p, containerId);
                if (container is null)
                {
                    return $"I can't find the {containerId}";
                }
            }


            string item_id = text[2];
            if (container is null)
            {
                return $"I can't find the {item_id}";
            }
            return this.LookAtIn(item_id, container);
        }

        public IHaveInventory FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }

        public string LookAtIn(string thingId, IHaveInventory container)
        {
            if (container is null)
            {
                return $"I can't find the {thingId}";
            }
            string result = "";
            try
            {
                GameObject obj = container.Locate(thingId);
                if (obj is null)
                {
                    result = $"I can't find the {thingId}";
                }
                else
                {
                    result = obj.FullDescription;
                }
            }
            catch (Exception ex)
            {
                result = $"I can't find the {thingId}";
            }

            return result;

        }
    }
}
