namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void MiMetodoDePrueba()
        {
            // L�gica de la prueba y afirmaciones aqu�
            Assert.AreEqual(2, 1 + 1);
        }
    }
}