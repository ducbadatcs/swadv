using NUnit.Framework.Internal;
using swadv;

namespace TestLocation
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestLocationIdentifyItself()
        {
            Location testLocation = new Location(new string[] { "test" }, "test", "test");
            GameObject obj = null;
            try
            {
                obj = testLocation.Locate(testLocation.FirstId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Assert.Fail(ex.Message);
            }
            finally
            {
                Assert.That(obj, Is.EqualTo(testLocation));
            }
        }

        [Test]
        public void TestLocationLocateItem()
        {
            Location testLocation = new Location(new string[] { "test" }, "test", "test");
            Item gem = new Item(new string[] { "gem" }, "gem", "gem");
            testLocation.Inventory.Put(gem);

            GameObject fetchItem = null;
            try
            {
                fetchItem = testLocation.Locate(gem.FirstId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Assert.Fail(ex.Message);
            }
            finally
            {
                Assert.That(fetchItem, Is.EqualTo(gem));
            }
        }
    }
}
