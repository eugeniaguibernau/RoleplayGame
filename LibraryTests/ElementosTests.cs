using Program.Elementos;

namespace LibraryTests
{
    public class ElementosTests
    {
        [Test]
        public void TestConstructor()
        {
            Elementos elemento = new Elementos("Espada", 10, 5, "Una espada afilada");
            Assert.AreEqual("Espada", elemento.Nombre);
            Assert.AreEqual(10, elemento.Ataque);
            Assert.AreEqual(5, elemento.Defensa);
        }

        [Test]
        public void TestNombreProperty()
        {
            Elementos elemento = new Elementos("Espada", 10, 5, "Una espada afilada");
            elemento.Nombre = "Hacha";
            Assert.AreEqual("Hacha", elemento.Nombre);
        }

        [Test]
        public void TestAtaqueProperty()
        {
            Elementos elemento = new Elementos("Espada", 10, 5, "Una espada afilada");
            elemento.Ataque = 15;
            Assert.AreEqual(15, elemento.Ataque);
        }

        [Test]
        public void TestDefensaProperty()
        {
            Elementos elemento = new Elementos("Espada", 10, 5, "Una espada afilada");
            elemento.Defensa = 8;
            Assert.AreEqual(8, elemento.Defensa);
        }
    }
}