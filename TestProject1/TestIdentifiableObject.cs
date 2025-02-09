using swadv;
namespace TestProject1
{
    public class Tests
    {
        public string[] identifiers;
        public IdentifiableObject id;

        [SetUp]
        public void Setup()
        {
            identifiers = new string[] { "105541452", "Duc", "Hoang" };
            id = new IdentifiableObject(identifiers);
        }

        [Test]
        public void TestAreYou()
        {
            // Test Are You
            Assert.That(id.AreYou("105541452"), Is.True);
        }

        [Test]
        public void TestNotAreYou()
        {
            Assert.That(id.AreYou("Nguyen"), Is.False);
        }

        [Test]
        public void TestCaseSensitive()
        {
            Assert.That(id.AreYou("dUC"), Is.True);
        }

        [Test]
        public void TestFirstId()
        {
            Assert.That(id.FirstId, Is.EqualTo(identifiers[0]));
        }


        [Test]
        public void TestFirstIdWithNoIds()
        {
            IdentifiableObject NoID = new IdentifiableObject(new string[] {});
            Assert.That(NoID.FirstId, Is.EqualTo(""));
        }

        [Test]
        public void TestAddId()
        {
            // create copy of id
            IdentifiableObject id_copy = id;
            try
            {
                id_copy.AddIdentifier("test");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail(ex.Message);
            }
            Assert.That(id_copy.AreYou("test"), Is.True);
        }

        [Test]
        public void TestPrivilegeEscalation()
        {
            IdentifiableObject id_copy = id;
            try
            {
                id_copy.PrivilegeEscalation("1452");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail(ex.Message);
            }
            Assert.That(id_copy.FirstId, Is.EqualTo("1452"));
        }
    }
}

