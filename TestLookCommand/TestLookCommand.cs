using swadv;
namespace TestLookCommand
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestLookAtMe()
        {
            LookCommand lc = new LookCommand();
            Player p = new Player("p", "test");
            string result = ""; // result should be nonempty
            try
            {
                lc.LookAtIn("inventory", p);
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
    }
}
