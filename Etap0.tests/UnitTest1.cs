using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Etap0.tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            Assert.True(2 == 2);
            Assert.False(1 == 343);
            
        }
    }
}