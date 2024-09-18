namespace LibraryTests
{
    public class MagoTests
    {
        [Test]
        public void TestObtenerValorAtaque()
        {
            // Crear elementos y hechizos
            var elemento1 = new Elementos("Báculo mágico", 20, 1, "Magia");
            var hechizo1 = new Hechizos("Bola de fuego", 30, 1, "Hechizo");

            // Crear mago y agregar elementos y hechizos
            var mago = new Mago("Mago poderoso", new List<Elementos> { elemento1 }, new List<Hechizos> { hechizo1 }, 100);

            // Verificar que el ataque total es la suma correcta
            Assert.That(mago.ObtenerValorDeAtaque(), Is.EqualTo(50));
        }

        [Test]
        public void TestObtenerValorDefensa()
        {
            // Crear elementos
            var elemento1 = new Elementos("Escudo de energía", 0, 15, "Protección");

            // Crear mago y agregar elementos
            var mago = new Mago("Mago defensor", new List<Elementos> { elemento1 }, new List<Hechizos>(), 100);

            // Verificar que la defensa total es la suma correcta
            Assert.That(mago.ObtenerValorDeDefensa(), Is.EqualTo(15));
        }

        [Test]
        public void TestMagoAtacaMago()
        {
            // Crear mago atacante
            var elementoAtaque = new Elementos("Varita", 25, 0, "Magia");
            var hechizoAtaque = new Hechizos("Rayo", 35, 1, "Hechizo");
            var magoAtacante = new Mago("Mago atacante", new List<Elementos> { elementoAtaque }, new List<Hechizos> { hechizoAtaque }, 100);

            // Crear mago defensor
            var elementoDefensa = new Elementos("Escudo mágico", 0, 20, "Defensa");
            var magoDefensor = new Mago("Mago defensor", new List<Elementos> { elementoDefensa }, new List<Hechizos>(), 100);

            // Mago atacante ataca al mago defensor
            magoDefensor.RecibirAtaque(magoAtacante);

            // Verificar vida restante
            double expectedDano = Math.Max(magoAtacante.ObtenerValorDeAtaque() - magoDefensor.ObtenerValorDeDefensa(), 0);
            double expectedVida = 100 - expectedDano;
            Assert.That(magoDefensor.Vida, Is.EqualTo(expectedVida));
        }

        [Test]
        public void TestElfoAtacaMago()
        {
            // Crear mago
            var elementoMago = new Elementos("Ropa mágica", 0, 10, "Protección");
            var mago = new Mago("Mago1", new List<Elementos> { elementoMago }, new List<Hechizos>(), 100);

            // Crear elfo atacante
            var elementoElfo = new Elementos("Arco", 30, 0, "Arma");
            var elfo = new Elfo("Elfo atacante", new List<Elementos> { elementoElfo }, 100);

            // Elfo ataca al mago
            mago.RecibirAtaque(elfo);

            // Verificar vida restante del mago
            double expectedDano = Math.Max(elfo.ObtenerValorDeAtaque() - mago.ObtenerValorDeDefensa(), 0);
            double expectedVida = 100 - expectedDano;
            Assert.That(mago.Vida, Is.EqualTo(expectedVida));
        }

        [Test]
        public void TestEnanoAtacaMago()
        {
            // Crear mago
            var elementoMago = new Elementos("Capa encantada", 0, 8, "Protección");
            var mago = new Mago("Mago2", new List<Elementos> { elementoMago }, new List<Hechizos>(), 100);

            // Crear enano atacante
            var elementoEnano = new Elementos("Martillo", 25, 0, "Arma");
            var enano = new Enanos("Enano atacante", new List<Elementos> { elementoEnano }, 100);

            // Enano ataca al mago
            mago.RecibirAtaque(enano);

            // Verificar vida restante del mago
            double expectedDano = Math.Max(enano.ObtenerValorDeAtaque() - mago.ObtenerValorDeDefensa(), 0);
            double expectedVida = 100 - expectedDano;
            Assert.That(mago.Vida, Is.EqualTo(expectedVida));
        }

        [Test]
        public void TestMagoSeCura()
        {
            // Crear mago con poca vida
            var magoDebil = new Mago("MagoDebilucho", new List<Elementos>(), new List<Hechizos>(), 10);

            // Mago se cura
            magoDebil.Curar();

            // Verificar que la vida aumentó correctamente (+15)
            Assert.That(magoDebil.Vida, Is.EqualTo(25));
        }
        
        [Test]
        public void TestAgregarHechizo()
        {
            // Crear un mago sin hechizos
            var mago = new Mago("Mago sin hechizos", new List<Elementos>(), new List<Hechizos>(), 100);
    
            // Crear un hechizo
            var hechizo = new Hechizos("Queso", 30, 1, "Hechizo");
    
            // Agregar el hechizo al mago
            mago.AgregarHechizo(hechizo);
    
            // Verificar que el hechizo fue agregado
            Assert.That(mago.LibroDeHechizos.Count, Is.EqualTo(1));
            Assert.That(mago.LibroDeHechizos[0].Nombre, Is.EqualTo("Queso"));
        }

        [Test]
        public void TestQuitarHechizo()
        {
            // Crear un mago con un hechizo
            var hechizo = new Hechizos("Bola de fraile", 30, 1, "Hechizo");
            var mago = new Mago("Mago con hechizos", new List<Elementos>(), new List<Hechizos> { hechizo }, 100);
    
            // Quitar el hechizo del mago
            mago.QuitarHechizo(hechizo);
    
            // Verificar que el hechizo fue removido
            Assert.That(mago.LibroDeHechizos.Count, Is.EqualTo(0));
        }
    }
}