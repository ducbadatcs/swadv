using swadv;

// I really need to visualize this one down
Player p = new Player("duc", "please help");
Item gem = new Item(new string[] { "gem" }, "gem", "some gem");
Bag bag = new Bag(new string[] { "bag" }, "bag", "a bag for items");

bag.Inventory.Put(gem);

p.Inventory.Put(bag);


LookCommand lookCommand = new LookCommand();

string[] command = "look at gem in bag".Split();
try
{
    Console.WriteLine(lookCommand.Execute(p, command));
}
catch (Exception ex)
{
    Console.WriteLine("Exception: ", ex.ToString());
    Console.WriteLine("StackTrace: ", ex.StackTrace);
    Console.WriteLine("Message: ", ex.Message);
}