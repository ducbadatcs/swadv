using swadv;

namespace TestPath
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestPathCanMovePlayer()
        {
            // test that path can move people
            Location testSource = new Location(new string[] { "source" }, "source", "source");
            Location testDestination = new Location(new string[] { "destination" }, "destination", "destination");
            swadv.Path testPath = new swadv.Path(new string[] { "test" }, "", "", testSource, testDestination);

            Player p = new Player("duc", "why");
            p.Location = testSource;

            try
            {
                testPath.MovePlayer(ref p);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Assert.Fail(ex.Message);
            }
            finally
            {
                Assert.That(p.Location.Name, Is.EqualTo(testDestination.Name));
            }
        }

        [Test]
        public void GetPathFromLocationGivenIdentifier()
        {
            Location testSource = new Location(new string[] { "source" }, "source", "source");
            Location testDestination = new Location(new string[] { "destination" }, "destination", "destination");
            swadv.Path testPath = new swadv.Path(new string[] { "test" }, "", "", testSource, testDestination);

            testDestination.AddPathTo(new string[] { "test" }, testSource);

            swadv.Path returnPath = null;
            try
            {
                returnPath = testDestination.GetPath("test");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Assert.Fail(ex.Message);
            }
            finally
            {
                Assert.That(returnPath, Is.Not.Null);
            }
        }

        [Test]
        public void TestPlayerMoveWhenGivenValidPathIndentifier()
        {
            // test that path can move people
            Location testSource = new Location(new string[] { "source" }, "source", "source");
            Location testDestination = new Location(new string[] { "destination" }, "destination", "destination");
            swadv.Path testPath = new swadv.Path(new string[] { "test" }, "", "", testSource, testDestination);

            testSource.AddPathTo(new string[] { "test" }, testDestination);

            Player p = new Player("duc", "why");
            p.Location = testSource;

            swadv.Path returnPath = null;
            try
            {
                returnPath = testSource.GetPath("test");
                returnPath.MovePlayer(ref p);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Assert.Fail(ex.Message);
            }
            finally
            {
                Assert.That(p.Location.Name, Is.EqualTo(testDestination.Name));
            }
        }

        [Test]
        public void TestPlayerNotMoveWhenGivenInvalidPathIndentifier()
        {
            Location testSource = new Location(new string[] { "source" }, "source", "source");
            Location testDestination = new Location(new string[] { "destination" }, "destination", "destination");
            swadv.Path testPath = new swadv.Path(new string[] { "test" }, "", "", testSource, testDestination);

            testSource.AddPathTo(new string[] { "test" }, testDestination);

            Player p = new Player("duc", "why");
            p.Location = testSource;

            swadv.Path returnPath = null;
            try
            {
                returnPath = testSource.GetPath("tes");
                if (!(returnPath is null))
                {
                    returnPath.MovePlayer(ref p);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Assert.Fail(ex.Message);
            }
            finally
            {
                Assert.That(p.Location.Name, Is.Not.EqualTo(testDestination.Name));
            }
        }
    }
}
