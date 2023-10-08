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
            // Lógica de la prueba y afirmaciones aquí
            Assert.AreEqual(2, 1 + 1);
        }
    }
}