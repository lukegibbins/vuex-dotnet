using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using NUnit.Framework;

namespace vuex.Tests.Services
{
    [TestFixture]
    public class FirebaseServiceTests
    {
        IFirebaseClient client;

        [SetUp]
        public void Init()
        {
            IFirebaseConfig config = new FirebaseConfig()
            {
                AuthSecret = "RGEVKFH5XCflUf5CgIpLs6ljgc1v39Dt7SvZKmq4",
                BasePath = "https://vuex-225ab.firebaseio.com"
            };

            client = new FirebaseClient(config);
        }

        [Test]
        public void TestFirebaseConnection()
        {
            Assert.AreEqual((int) client.Get("/contacts").StatusCode, 200);
        }
    }
}
