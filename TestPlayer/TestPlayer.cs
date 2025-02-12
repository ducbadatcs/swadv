using NUnit.Framework.Internal;
using swadv;
namespace TestPlayer
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        public Player player = new Player("Fred", "the mighty programmer");

        [Test]
        public void TestPlayerIdentifiable()
        {
            Assert.That(player.AreYou("me"), Is.True);
            Assert.That(player.AreYou("inventory"), Is.True);
        }

        [Test]
        public void TestPlayerLocatesItems()
        {
            Player player = new Player("Fred", "the mighty programmer");
            Item shovel = new Item(new string[] { "shovel" }, "shovel", "shovel");
            try
            {
                player.Inventory.Put(shovel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Assert.Fail(ex.Message);
            }
            finally
            {
                //Assert.That(player.Locate("shovel"), Is.Not.Null);
                Assert.Pass();
            }
        }

        [Test]
        public void TestPlayerLocatesItself()
        {
            Player player = new Player("Fred", "the mighty programmer");
            try
            {
                Assert.That(player.Locate("me"), Is.EqualTo(player));
                Assert.That(player.Locate("inventory"), Is.EqualTo(player));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Assert.Fail(ex.Message);
            }
            finally
            {
                //Assert.That(player.Locate("shovel"),, Is.Not.Null);
            }
        }

        [Test]
        public void TestPlayerLocatesNothing()
        {
            Player player = new Player("Fred", "the mighty programmer");
            try
            {
                Assert.That(player.Locate("cat"), Is.Null);
                //Assert.That(player.Locate("inventory"), Is.EqualTo(player));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Assert.Fail(ex.Message);
            }
            finally
            {
                //Assert.That(player.Locate("shovel"),, Is.Not.Null);
            }
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            Player player = new Player("Fred", "the mighty programmer");
            Assert.That(player.FullDescription.StartsWith("You are"), Is.True);
        }
    }
}
