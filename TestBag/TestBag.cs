using swadv;
namespace TestBag
{
    public class Tests
    {
        Item shovel = new Item(new string[] { "shovel" }, "shovel", "shovel");
        Item bronze_sword = new Item(new string[] { "sword" }, "bronze sword", "sword");
        Item small_computer = new Item(new string[] { "pc" }, "small computer", "computer");
        //public Bag bag = new Bag(new string[] { "bag" }, "Bag", "a bag I guess");

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestBagLocatesItems()
        {
            Item test = new Item(new string[] { "test" }, "test item", "Item for testing");
            Bag bag = new Bag(new string[] { "bag" }, "Bag", "a bag I guess");
            try
            {
                bag.Inventory.Put(test);
                var obj = bag.Locate(test.FirstId);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Assert.Fail(ex.Message);
            }
            finally
            {
                Assert.That(bag.Locate(test.FirstId), Is.Not.Null);
                Assert.Pass();
            }
        }

        [Test]
        public void TestBagLocatesItself()
        {
            Bag bag = new Bag(new string[] { "bag" }, "Bag", "a bag I guess");
            GameObject obj = new GameObject(new string[] { "bag" }, "", "");
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Assert.Fail(ex.Message);
            }
            finally
            {
                Assert.That(obj.FirstId, Is.Not.EqualTo("null"));
            }
        }

        [Test]
        public void TestBagLocatesNothing()
        {
            Bag bag = new Bag(new string[] { "bag" }, "Bag", "a bag I guess");
            //GameObject cat = new GameObject(new string[] { "cat" }, "", "");
            GameObject obj = new GameObject(new string[] { "" }, "", "");
            try
            {
                obj = bag.Locate("cat");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Assert.Fail(ex.Message);
            }
            finally
            {
                Assert.That(obj, Is.Null);
            }
        }

        [Test]
        public void TestBagFullDescription()
        {
            // idk what to print here
            Bag bag = new Bag(new string[] { "bag" }, "Bag", "a bag I guess");
            Item shovel = new Item(new string[] { "shovel" }, "shovel", "shovel");
            //Item bronze_sword = new Item(new string[] { "sword" }, "bronze sword", "sword");
            //Item small_computer = new Item(new string[] { "pc" }, "small computer", "computer");

            bag.Inventory.Put(shovel);
            Console.WriteLine(bag.FullDescription);
            Assert.That(
                bag.FullDescription.StartsWith("In the " + bag.Name + " you can see"), Is.True);
        }

        [Test]
        public void TestBagInBag()
        {
            Bag b1 = new Bag(new string[] { "b1" }, "", "");
            Bag b2 = new Bag(new string[] { "b2" }, "", "");

            Item shovel = new Item(new string[] { "shovel" }, "shovel", "shovel");
            Item small_computer = new Item(new string[] { "pc" }, "small computer", "computer");

            try
            {
                b2.Inventory.Put(small_computer);
                b1.Inventory.Put(b2);
                b1.Inventory.Put(shovel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Assert.Fail(ex.Message);
            }
            finally
            {
                Assert.That(b1.Locate("b2"), Is.Not.Null);
                Assert.That(b1.Locate("shovel"), Is.Not.Null);
                Assert.That(b1.Locate("pc"), Is.Null);
            }
        }
    }
}
