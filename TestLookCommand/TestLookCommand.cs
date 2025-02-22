using swadv;
namespace TestLookCommand
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        public LookCommand lookCommand = new LookCommand();
        //Player p = new Player("p", "test");

        [Test]
        public void TestLookAtMe()
        {

            Player p = new Player("p", "test");
            string result = ""; // result should be nonempty
            try
            {
                result = lookCommand.LookAtIn("inventory", p);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.StackTrace);
                Assert.Fail(ex.Message);
            }
            finally
            {
                Assert.That(result, Is.Not.Empty);
            }
        }

        [Test]
        public void TestLookAtGem()
        {
            Player p = new Player("p", "test");
            Item gem = new Item(new string[] { "gem" }, "gem", "some description");

            p.Inventory.Put(gem);

            string result = "";

            try
            {
                result = lookCommand.LookAtIn(gem.FirstId, p);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.StackTrace);
                Assert.Fail(ex.Message);
            }
            finally
            {
                Assert.That(result, Is.EqualTo(gem.FullDescription));
            }
        }

        [Test]
        public void TestLookAtUnk()
        {
            // look at unknown? 

            // declare new player is enough
            Player p = new Player("p", "test");
            string result = "";

            try
            {
                result = lookCommand.LookAtIn("gem", p);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.StackTrace);
                Assert.Fail(ex.Message);
            }
            finally
            {
                Assert.That(result, Is.EqualTo("I can't find the gem"));
            }
        }

        [Test]
        public void LookAtGemInMe()
        {
            Player p = new Player("p", "test");
            Item gem = new Item(new string[] { "gem" }, "gem", "some description");

            p.Inventory.Put(gem);
            string result = "";

            try
            {
                result = lookCommand.Execute(p, "look at gem in inventory".Split());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.StackTrace);
                Assert.Fail(ex.Message);
            }
            finally
            {
                Assert.That(result, Is.EqualTo(gem.FullDescription));
            }
        }

        [Test]
        public void TestLookAtGemInBag()
        {
            Player p = new Player("p", "test");
            Item gem = new Item(new string[] { "gem" }, "gem", "some description");
            Bag bag = new Bag(new string[] { "bag" }, "bag", "a bag");

            bag.Inventory.Put(gem);
            p.Inventory.Put(bag);
            string result = "";

            try
            {
                result = lookCommand.Execute(p, "look at gem in bag".Split());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.StackTrace);
                Assert.Fail(ex.Message);
            }
            finally
            {
                Assert.That(result, Is.EqualTo(gem.FullDescription));
            }
        }

        [Test]
        public void TestLookAtGemInNoBag()
        {
            Player p = new Player("p", "test");
            Item gem = new Item(new string[] { "gem" }, "gem", "some description");
            Bag bag = new Bag(new string[] { "bag" }, "bag", "a bag");

            bag.Inventory.Put(gem);

            // yeah I can just remove this line
            //p.Inventory.Put(bag);

            string result = "";

            try
            {
                result = lookCommand.Execute(p, "look at gem in bag".Split());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.StackTrace);
                Assert.Fail(ex.Message);
            }
            finally
            {
                Assert.That(result, Is.EqualTo("I can't find the bag"));
            }
        }

        [Test]
        public void TestLookAtNoGemInBag()
        {
            Player p = new Player("p", "test");
            Item gem = new Item(new string[] { "gem" }, "gem", "some description");
            Bag bag = new Bag(new string[] { "bag" }, "bag", "a bag");

            //bag.Inventory.Put(gem);

            p.Inventory.Put(bag);

            string result = "";

            try
            {
                result = lookCommand.Execute(p, "look at gem in bag".Split());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.StackTrace);
                Assert.Fail(ex.Message);
            }
            finally
            {
                Assert.That(result, Is.EqualTo("I can't find the gem"));
            }
        }

        [Test]
        public void TestInvalidLook()
        {
            Dictionary<string, string> testsAndExpectedResults = new Dictionary<string, string>()
            {
                { "look around", "I don't know how to look like that" },
                { "look around in house", "I don't know how to look like that" },
                { "hello duc lmao", "Error in look input" },
                { "look in house", "What do you want to look at?" },
                { "look at a at b", "What do you want to look in?" },
            };

            Player p = new Player("p", "test");
            foreach (KeyValuePair<string, string> test in testsAndExpectedResults)
            {
                string result = "";
                try
                {
                    result = lookCommand.Execute(p, test.Key.Split(' '));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    Console.WriteLine(ex.StackTrace);
                    Assert.Fail(ex.Message);
                }
                finally
                {
                    Console.WriteLine(test.Key);
                    Assert.That(result, Is.EqualTo(test.Value));
                }
            }
        }
    }
}
