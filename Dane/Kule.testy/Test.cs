using Dane;
using Logika;

namespace Kule.testy
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void KulaKonstruktor()
        {
            int[] c = {11, 22, 33};
            ICommandKula k = new Kula(100, 200, 30, 1, 2, c);
            Assert.AreEqual(k.XPosition, 100);
            Assert.AreEqual(k.YPosition, 200);
            Assert.AreEqual(k.Radius, 30);
            Assert.AreEqual(k.XSpeed, 1);
            Assert.AreEqual(k.YSpeed, 2);
            Assert.AreEqual(k.BaseColor, c);
            Assert.AreEqual(k.CurrentColor, c);
            Assert.AreEqual(k.Mass, 30*30);

        }

        [TestMethod]
        public void KulaSettery()
        {
            int[] c1 = {11, 22, 33};
            int[] c2 = {12, 23, 34};
            ICommandKula k = new Kula(100, 200, 30, 1, 2, c1);
            k.XPosition = 101;
            k.YPosition = 201;
            k.Radius = 31;
            k.XSpeed = 3;
            k.YSpeed = 4;
            k.BaseColor = c2;
            k.CurrentColor = c2;
            Assert.AreEqual(k.XPosition, 101);
            Assert.AreEqual(k.YPosition, 201);
            Assert.AreEqual(k.Radius, 31);
            Assert.AreEqual(k.XSpeed, 3);
            Assert.AreEqual(k.YSpeed, 4);
            Assert.AreEqual(k.BaseColor, c2);
            Assert.AreEqual(k.CurrentColor, c2);
        }

        [TestMethod]
        public void BasenTworzenieKul()
        {
            int[] c = {11, 22, 33};
            ICommandBasen basen = new Basen();
            basen.createBall(100, 200, 10, 1, 2, c);
            Assert.AreEqual(basen.getBallCount(), 1);
            Assert.AreEqual(basen.getBall(0).XPosition, 100);
            Assert.AreEqual(basen.getBall(0).YPosition, 200);
            Assert.AreEqual(basen.getBall(0).Radius, 10);
        }

        [TestMethod]
        public void BasenAktualizacjaKul()
        {
            int[] c = {11, 22, 33};
            ICommandBasen basen = new Basen();
            basen.createBall(100, 200, 10, 1, 2, c);
            basen.updateBall(0, 11, 21);
            Assert.AreEqual(basen.getBall(0).XPosition, 11);
            Assert.AreEqual(basen.getBall(0).YPosition, 21);
        }

        [TestMethod]
        public void BasenZawartoœæ()
        {
            int[] c = { 11, 22, 33 };
            ICommandBasen basen = new Basen();
            Assert.AreEqual(basen.getBallCount(), 0);
            basen.createBall(100, 200, 10, 1, 2, c);
            Assert.AreEqual(basen.getBallCount(), 1);
            basen.createBall(200, 300, 10, 1, 2, c);
            Assert.AreEqual(basen.getBallCount(), 2);
            basen.createBall(300, 400, 10, 1, 2, c);
            Assert.AreEqual(basen.getBallCount(), 3);
            basen.deleteBall(2);
            Assert.AreEqual(basen.getBallCount(), 2);
            basen.clean();
            Assert.AreEqual(basen.getBallCount(), 0);
        }

        [TestMethod]
        public void BasenWyj¹tkiKul()
        {
            ICommandBasen basen = new Basen();
            int[] c = { 11, 22, 33 };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => basen.createBall(-1,10,1, 0, 0, c));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => basen.createBall(10, -1, 1, 0, 0, c));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => basen.createBall(10, 10, 0, 0, 0, c));
            Assert.ThrowsException<ArgumentNullException>(() => basen.getBall(350));
        }

        [TestMethod]
        public void InitializeTest()
        {
            ICommandLogika logika = new Logika.Logika();
            logika.Initialize(800, 600, 5, 10);
            Assert.AreEqual(logika.GetNumberOfThreads(), 5);
            Assert.AreEqual(logika.GetNumberOfBalls(), 5);
            for(int i=0; i<5; i++)
            {
                Assert.IsTrue(0 < logika.GetRadius(i) && logika.GetRadius(i) <= 20);
            }
            
        }
    }
}