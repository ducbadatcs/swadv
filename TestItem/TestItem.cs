using swadv;
namespace TestItem
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        // item taken from assignment paper
        public Item shovel = new Item
        (
            new String[] { "shovel", "spade" }, 
            "a shovel", 
            "This is a might fine ..."
        );

        [Test]
        public void TestItemIsIdentifiable()
        {
            Assert.That(shovel.AreYou("shovel"), Is.True);
            Assert.That(shovel.AreYou("sword"), Is.False);
        }

        [Test]
        public void TestShortDescription()
        {
            // test that Short Description matches the format?
            GameObject brown_sword = new GameObject(new string[] {"sword"}, "bronze sword", "sword");
            Console.WriteLine(brown_sword.ShortDescription);
            Assert.That(brown_sword.ShortDescription, Is.EqualTo("a bronze sword (sword)"));
        }

        [Test]
        public void TestLongDescription()
        {
            // idk what to go here
            try
            {
                string dummy = shovel.LongDescription;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            finally
            {
                Assert.Pass();
            }
        }

        [Test]
        public void TestPrivilegeEscalation()
        {
            GameObject shovel_copy = shovel;
            shovel_copy.PrivilegeEscalation("1452");
            Assert.That(shovel_copy.FirstId, Is.EqualTo("1452"));
        }
    }
}
