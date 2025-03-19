namespace swadv
{
    public abstract class Command : IdentifiableObject
    {
        public Command(string[] ids) : base(ids) { }

        public abstract string Execute(ref Player p, string[] text);
    }
}
