using swadv;

// Get the player's name and description from the user, and use these details to create a 
// Player object. 
Console.Write("Enter player name: ");
string playerName = Console.ReadLine() ?? "";

Console.Write("Enter player description: ");
string playerDescription = Console.ReadLine() ?? "";

Player player = new Player(playerName, playerDescription);

// Create two items and add them to the the player's inventory 
Item gem = new Item(new string[] { "gem" }, "gem", "a gem");
Item shovel = new Item(new string[] { "shovel" }, "shovel", "a shovel");
player.Inventory.Put(gem);
player.Inventory.Put(shovel);

// Create a bag and add it to the player's inventory 
Bag bag = new Bag(new string[] { "bag" }, "bag", "a bag");
player.Inventory.Put(bag);

// Create another item and add it to the bag 
Item bomb = new Item(new string[] { "bomb" }, "bomb", "it explodes I guess");
bag.Inventory.Put(bomb);

// Loop reading commands from the user, and getting the look command to execute them. 
LookCommand lookCommand = new LookCommand();

while (true)
{
    Console.Write("> ");
    string input = Console.ReadLine() ?? "";
    input = input.ToLower(); // can't do that on the line above because null 
    // a nice feature
    var split = input.Split(' ');
    if (split.Contains("exit"))
    {
        break;
    }
    Console.WriteLine(lookCommand.Execute(player, split) + "\n");
}