using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swadv
{
    class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] {"move", "go", "head", "leave" }){ }

        /// <summary>
        /// idea: we do something like "head east" then we pick the path with the identifier 
        /// "east" and move along that
        /// </summary>
        /// <param name="p"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public override string Execute(ref Player p, string[] text)
        {
            if (text.Length != 2)
            {
                return "I don't know how to go like that.";
            }

            string direction = text[1];
            Path path = p.Location.GetPath(direction);
            if (path is null)
            {
                return "I can't go in that direction!";
            }
            else
            {
                path.MovePlayer(ref p);
                return $"Success! You are now in: {p.Location.Name}";
            }
        }
    }
}
