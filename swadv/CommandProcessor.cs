using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swadv
{
    public class CommandProcessor
    {
        private List<Command> _commands = new List<Command>()
        {
            new LookCommand(),
            new MoveCommand(),
        };

        public CommandProcessor() 
        {
            this._commands = new List<Command>()
            {
                new LookCommand(),
                new MoveCommand(),
            };
        }

        public string Execute(ref Player p, string[] text)
        {
            if (text.Length == 0)
            {
                return "";
            }
            string commandIdentifier = text[0];
            foreach (var command in this._commands)
            {
                if (command.AreYou(commandIdentifier))
                {
                    return command.Execute(ref p, text);
                }
            }
            return "Command not found!";
        }
    }
}
