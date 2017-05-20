using Moq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace WatchShop.Tests
{
    public class UnitTestBase
    {
        protected MockRepository MockRepository { get; private set; }

        [OneTimeSetUp]
        public void TestSetUp()
        {
            MockRepository = new MockRepository(MockBehavior.Strict);
        }

        [TearDown]
        public void TestTearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
            {
                MockRepository.VerifyAll();
            }
        }
    }
}