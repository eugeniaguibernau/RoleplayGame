namespace LibraryTests
{
    public class ElfoTests
    {
        [Test]
        public void TestObtenerValorAtaque()
        {
            // Crear elementos
            var elemento1 = new Elementos("Espada de chocolate", 15, 2, "Espada");
            var elemento2 = new Elementos("Rifle de caza con gatillo derretido", 10, 3, "Arma larga");

            // Crear elfo y agregar elementos
            var elfo = new Elfo("Elfo pedante", new List<Elementos> { elemento1 }, 100);
            elfo.AgregarElemento(elemento2);

            // Verificar que el ataque total es la suma correcta
            Assert.That(elfo.ObtenerValorDeAtaque(), Is.EqualTo(25));
        }

        [Test]
        public void TestObtenerValorDefensa()
        {
            // Crear elementos
            var elemento1 = new Elementos("Escudo", 0, 10, "Defensa");
            var elemento2 = new Elementos("Armadura", 0, 5, "Protección");

            // Crear elfo y agregar elementos
            var elfo = new Elfo("Elfo2", new List<Elementos> { elemento1 }, 100);
            elfo.AgregarElemento(elemento2);

            // Verificar que la defensa total es la suma correcta
            Assert.That(elfo.ObtenerValorDeDefensa(), Is.EqualTo(15));
        }

        [Test]
        public void TestElfoAtacaElfo()
        {
            // Crear elfo atacante
            var elementoAtaque = new Elementos("Espada", 20, 5, "Arma");
            var elfoAtacante = new Elfo("Elfo Atacante enojado", new List<Elementos> { elementoAtaque }, 100);

            // Crear elfo defensor
            var elementoDefensa = new Elementos("Escudo", 5, 10, "Defensa");
            var elfoDefensor = new Elfo("ElfoDefensor", new List<Elementos> { elementoDefensa }, 100);

            // Elfo atacante ataca al elfo defensor
            elfoDefensor.RecibirAtaque(elfoAtacante);

            // Verificar la vida restante
            double expectedDano = Math.Max(elfoAtacante.ObtenerValorDeAtaque() - elfoDefensor.ObtenerValorDeDefensa(), 0);
            double expectedVida = 100 - expectedDano;
            Assert.That(elfoDefensor.Vida, Is.EqualTo(expectedVida));
        }

        [Test]
        public void TestMagoAtacaElfo()
        {
            // Crear elfo
            var elementoElfo = new Elementos("Armadura", 0, 5, "Protección");
            var elfo = new Elfo("Elfo1", new List<Elementos> { elementoElfo }, 100);

            // Crear mago
            var elementoMago = new Elementos("Palo de madera con brillo", 30, 0, "Magia");
            var mago = new Mago("Mago1", new List<Elementos> { elementoMago }, new List<Hechizos>(), 100);

            // Mago ataca al elfo
            elfo.RecibirAtaque(mago);

            // Verificar vida restante del elfo
            double expectedDano = Math.Max(mago.ObtenerValorDeAtaque() - elfo.ObtenerValorDeDefensa(), 0);
            double expectedVida = 100 - expectedDano;
            Assert.That(elfo.Vida, Is.EqualTo(expectedVida));
        }

        [Test]
        public void TestEnanoAtacaElfo()
        {
            // Crear elfo
            var elementoElfo2 = new Elementos("Pechera de hierro", 0, 10, "Protección");
            var elfo2 = new Elfo("Elfo2", new List<Elementos> { elementoElfo2 }, 100);

            // Crear enano
            var elementoEnano = new Elementos("Tijera", 20, 0, "Herramienta");
            var enano = new Enanos("Enano gordo", new List<Elementos> { elementoEnano }, 100);

            // Enano ataca al elfo
            elfo2.RecibirAtaque(enano);

            // Verificar vida restante del elfo
            double expectedDano = Math.Max(enano.ObtenerValorDeAtaque() - elfo2.ObtenerValorDeDefensa(), 0);
            double expectedVida = 100 - expectedDano;
            Assert.That(elfo2.Vida, Is.EqualTo(expectedVida));
        }

        [Test]
        public void TestElfoSeCura()
        {
            // Crear elfo con poca vida
            var elfoDebil = new Elfo("ElfoDebilucho", new List<Elementos>(), 20);

            // Elfo se cura
            elfoDebil.Curar();

            // Verificar que la vida aumentó correctamente (+10)
            Assert.That(elfoDebil.Vida, Is.EqualTo(30));
        }
    }
}