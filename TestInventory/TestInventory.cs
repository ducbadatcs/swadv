using swadv;
namespace TestInventory
{
    public class Tests
    {
        public Inventory inventory = new Inventory();
        Item shovel = new Item(new string[] { "shovel" }, "shovel", "shovel");
        Item bronze_sword = new Item(new string[] { "sword" }, "bronze sword", "sword");
        Item small_computer = new Item(new string[] { "pc" }, "small computer", "computer");

        [SetUp]
        public void Setup()
        {
            inventory.Put(shovel);
            inventory.Put(bronze_sword);
            inventory.Put(small_computer);
        }

        [Test]
        public void TestFindItem()
        {
            Assert.That(inventory.AreYou("pc"), Is.True);
        }

        [Test]
        public void TestNoFindItem()
        {
            Assert.That(inventory.AreYou("cat"), Is.False);
        }

        [Test]
        public void TestFetchItem()
        {
            try
            {
                inventory.Fetch("pc");
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                Assert.Fail(ex.Message);
            }
            Assert.That(inventory.AreYou("pc"), Is.True);
        }

        [Test]
        public void TestItemList()
        {
            try
            {
                Console.WriteLine(inventory.ItemList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail(ex.Message);
            }
            Assert.Pass();
        }

        [Test]
        public void TestTakeItem()
        {
            try
            {
                inventory.Take("sword");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail(ex.Message);
            }
            Assert.That(inventory.AreYou("sword"), Is.False);
        }
    }
}
