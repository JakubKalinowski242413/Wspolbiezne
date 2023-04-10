using System.Drawing;

namespace Kule.tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void constructorTest()
        {
            Kule.Dane.Kula kula = new Dane.Kula(5, 10, 10, 20, 20, Brushes.Red);

            Assert.AreEqual(kula.Promien, 5);
            Assert.AreEqual(kula.PozycjaX, 10);
            Assert.AreEqual(kula.PozycjaY, 10);
            Assert.AreEqual(kula.PredkoscX, 20);
            Assert.AreEqual(kula.PredkoscY, 20);
            Assert.AreEqual(kula.Kolor, Brushes.Red);
        }

        [TestMethod]
        public void updateBallTest()
        {
            Kule.Dane.Kula kula = new Dane.Kula(5, 10, 10, 20, 20, Brushes.Red);
            kula.PozycjaX = 30;
            kula.PredkoscY = 50;
            kula.Kolor = Brushes.Blue;

            Assert.AreEqual(kula.PozycjaX, 30);
            Assert.AreEqual(kula.PredkoscY, 50);
            Assert.AreEqual(kula.Kolor, Brushes.Blue);
        }

        [TestMethod]
        public void masaTest()
        {
            Kule.Dane.Kula kula = new Dane.Kula(5, 10, 10, 20, 20, Brushes.Red);

            Assert.AreEqual(kula.Masa, 25);
            kula.Promien = 10;
            Assert.AreEqual(kula.Masa, 100);
        }


    }
}