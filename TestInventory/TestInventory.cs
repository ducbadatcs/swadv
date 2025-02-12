using swadv;
namespace TestInventory
{
    public class Tests
    {
        public Inventory inventory = new Inventory();
        public Item shovel = new Item(new string[] { "shovel" }, "shovel", "shovel");
        public Item bronze_sword = new Item(new string[] { "sword" }, "bronze sword", "sword");
        public Item small_computer = new Item(new string[] { "pc" }, "small computer", "computer");

        [SetUp]
        public void Setup()
        {
            inventory.Put(shovel);
            inventory.Put(bronze_sword);
            inventory.Put(small_computer);
            //Console.WriteLine(inventory.ItemList);
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
                Console.WriteLine(ex.StackTrace);
                Assert.Fail(ex.Message);
            }
            finally
            {
                Assert.Pass();
            }
        }

        [Test]
        public void TestFindItem()
        {
            Assert.That(inventory.HasItem("pc"), Is.True);
        }

        [Test]
        public void TestNoFindItem()
        {
            Assert.That(inventory.HasItem("cat"), Is.False);
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
                Console.WriteLine(ex.StackTrace);
                Assert.Fail(ex.Message);
            }
            finally
            {
                Assert.That(inventory.HasItem("pc"), Is.True);
            }
        }



        [Test]
        public void TestTakeItem()
        {
            Inventory test_inventory = new Inventory();
            try
            {
                // dude, setup is done multiple times
                test_inventory.Put(bronze_sword);
                test_inventory.Take("sword");
                Console.WriteLine(test_inventory.ItemList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Assert.Fail(ex.Message);
            }
            finally
            {
                Assert.That(test_inventory.HasItem("sword"), Is.False);
            }
        }
    }
}
