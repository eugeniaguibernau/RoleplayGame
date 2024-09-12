namespace LibraryTests
{
    using NUnit.Framework;

    public class HechizosTests
    {
        [Test]
        public void TestConstructor()
        {
            Hechizos hechizo = new Hechizos("Fuego", 20, 10, "Ofensivo");
            Assert.AreEqual("Fuego", hechizo.Nombre);
            Assert.AreEqual(20, hechizo.Ataque);
            Assert.AreEqual(10, hechizo.Defensa);
            Assert.AreEqual("Ofensivo", hechizo.Tipo);
        }

        [Test]
        public void TestNombreProperty()
        {
            Hechizos hechizo = new Hechizos("Fuego", 20, 10, "Ofensivo");
            hechizo.Nombre = "Hielo";
            Assert.AreEqual("Hielo", hechizo.Nombre);
        }

        [Test]
        public void TestAtaqueProperty()
        {
            Hechizos hechizo = new Hechizos("Fuego", 20, 10, "Ofensivo");
            hechizo.Ataque = 25;
            Assert.AreEqual(25, hechizo.Ataque);
        }

        [Test]
        public void TestDefensaProperty()
        {
            Hechizos hechizo = new Hechizos("Fuego", 20, 10, "Ofensivo");
            hechizo.Defensa = 15;
            Assert.AreEqual(15, hechizo.Defensa);
        }

        [Test]
        public void TestTipoProperty()
        {
            Hechizos hechizo = new Hechizos("Fuego", 20, 10, "Ofensivo");
            hechizo.Tipo = "Defensivo";
            Assert.AreEqual("Defensivo", hechizo.Tipo);
        }
    }
}