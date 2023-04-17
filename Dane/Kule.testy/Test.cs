using Dane;
using Logika;

namespace Kule.testy
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TworzenieKul()
        {
            ICommandBasen basen = new Basen();
            basen.createBall(20, 15, 10);
            Assert.AreEqual(basen.getBallCount(), 1);
            Assert.AreEqual(basen.getBall(0).XAxis, 20);
            Assert.AreEqual(basen.getBall(0).YAxis, 15);
            Assert.AreEqual(basen.getBall(0).Radius, 10);
        }

        [TestMethod]
        public void AktualizacjaKul()
        {
            ICommandBasen basen = new Basen();
            basen.createBall(1, 1, 1);
            basen.updateBall(0, 10, 20);
            Assert.AreEqual(basen.getBall(0).XAxis, 10);
            Assert.AreEqual(basen.getBall(0).YAxis, 20);
        }

        [TestMethod]
        public void Wyj¹tkiKul()
        {
            ICommandBasen basen = new Basen();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => basen.createBall(-1,0,0));
            Assert.ThrowsException<ArgumentNullException>(() => basen.getBall(350));
        }

        [TestMethod]
        public void PoprawnoscDanych()
        {
            ICommandLogika logika = new Logika.Logika();
            logika.Initialize(800, 600, 5, 10);
            for (int i = 0; i < logika.GetNumberOfDirections(); i++)
            {
                Assert.IsTrue(logika.get)
            }
        }

        [TestMethod]
        public void InitializeTest()
        {
            ICommandLogika logika = new Logika.Logika();
            logika.Initialize(800, 600, 5, 10);
            Assert.AreEqual(logika.GetNumberOfThreads(), 5);
            Assert.AreEqual(logika.GetNumberOfDirections(), 5);
        }
    }
}