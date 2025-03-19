using swadv;
using System.Net.Sockets;

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
Item shotgun = new Item(new string[] { "shotgun" }, "shotgun", "American high school simulator");
Item pillow = new Item(new string[] { "pillow" }, "pillow", "why is this here");

Location[] locations = new Location[4] ;

Item[] items = new Item[]{gem, shovel, shotgun, pillow};

for (int i = 0; i < 4; i++)
{
    locations[i] = new Location(new string[] { $"location_{i}" }, $"location_{i}", "something");
    locations[i].Inventory.Put(items[i]);
}

// link locations together
for (int i = 0; i < locations.Count(); i++)
{
    for (int j = i + 1; j < locations.Count(); j++)
    {
        locations[i].AddPathTo(new string[] { j.ToString() }, locations[j]);
        locations[j].AddPathTo(new string[] { i.ToString() }, locations[i]);
    }
}

CommandProcessor commandProcessor = new CommandProcessor();

player.Location = locations[0];

while (true)
{
    Console.WriteLine($"You are in {player.Location.Name}\n" +
        $"Available items: {string.Join(" ", player.Location.Inventory.ItemList)}\n" +
        $"Available Paths: {player.Location.AllPaths}");
    Console.Write("> ");
    string input = (Console.ReadLine() ?? "").ToLower();
     
    // a nice feature
    var split = input.Split(' ');
    if (split.Contains("exit"))
    {
        break;
    }
    Console.WriteLine(commandProcessor.Execute(ref player, split));
}