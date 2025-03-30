using swadv;
namespace TestCommandProcessor
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestExecuteLookCommand()
        {
            Player p = new Player("duc", "lmao");
            Item gem = new Item(new string[] { "gem" }, "gem", "gem");
            p.Inventory.Put(gem);
            CommandProcessor commandProcessor = new CommandProcessor();

            Assert.That(commandProcessor.Execute(ref p, "look at gem in me".Split()), Is.EqualTo("gem"));
        }

        [Test]
        public void TestExecuteMoveCommand()
        {
            Player p = new Player("duc", "lmao");
            Location start = new Location(new string[] { "start" }, "start", "start");
            Location end = new Location(new string[] { "end" }, "end", "end");

            start.AddPathTo(new string[] { "end" }, end);

            p.Location = start;
            swadv.Path path = new swadv.Path(new string[] { "test" }, "test", "test", start, end);
            CommandProcessor commandProcessor = new CommandProcessor();

            Assert.That(commandProcessor.Execute(ref p, "head end".Split()), Is.EqualTo($"Success! You are now in: {end.Name}"));
        }
    }
}
