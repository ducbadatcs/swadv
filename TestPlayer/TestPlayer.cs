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

        }
    }
}
