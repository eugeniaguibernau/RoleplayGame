using Program.Elementos;
using Program.Interfaces;

namespace LibraryTests
{
    public class ElfoTests
    {
        [Test]
        public void TestObtenerValorAtaque()
        {
            // Crear items de ataque
            var espada = new Espada("Espada de chocolate", 15, 5);
            var arco = new Arco("Rifle de caza con gatillo derretido", 10);

            // Crear elfo y agregar elementos de ataque
            var elfo = new Elfo("Elfo pedante", new List<IElementos> { espada }, 100);
            elfo.AgregarElemento(arco);

            // Verificar que el ataque total es la suma correcta
            Assert.That(elfo.ObtenerValorDeAtaque(), Is.EqualTo(25));
        }

        [Test]
        public void TestObtenerValorDefensa()
        {
            // Crear items de defensa
            var escudo = new Escudo("Escudo", 10);
            var espada = new Espada("Espada de chocolate", 15, 5);

            // Crear elfo y agregar elementos de defensa
            var elfo = new Elfo("Elfo defensor", new List<IElementos> { escudo }, 100);
            elfo.AgregarElemento(espada);

            // Verificar que la defensa total es la suma correcta
            Assert.That(elfo.ObtenerValorDeDefensa(), Is.EqualTo(15));
        }

        [Test]
        public void TestElfoAtacaElfo()
        {
            // Crear elfo atacante
            var espada = new Espada("Espada", 20, 5);
            var elfoAtacante = new Elfo("Elfo Atacante enojado", new List<IElementos> { espada }, 100);

            // Crear elfo defensor
            var escudo = new Escudo("Escudo", 10);
            var elfoDefensor = new Elfo("Elfo Defensor", new List<IElementos> { escudo }, 100);

            // Elfo atacante ataca al elfo defensor
            elfoDefensor.RecibirAtaque(elfoAtacante);

            // Verificar la vida restante
            double expectedDano =
                Math.Max(elfoAtacante.ObtenerValorDeAtaque() - elfoDefensor.ObtenerValorDeDefensa(), 0);
            double expectedVida = 100 - expectedDano;
            Assert.That(elfoDefensor.Vida, Is.EqualTo(expectedVida));
        }

        [Test]
        public void TestMagoAtacaElfo()
        {
            // Crear elfo
            var escudo = new Escudo("Armadura", 5);
            var elfo = new Elfo("Elfo 1", new List<IElementos> { escudo }, 100);


            var bastonMagico = new BastonMagico("Palo de madera con brillo", 30, 5, 2);
            var mago = new Mago("Mago 1", new List<IElementos> { bastonMagico }, new List<IHechizo>(),
                100);

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
            var armaduraHierro = new Escudo("Pechera de hierro", 10);
            var elfo = new Elfo("Elfo 2", new List<IElementos> { armaduraHierro }, 100);

            // Crear enano
            var tijera = new Tijera("Tijera", 20, 2);
            var enano = new Enanos("Enano Gordo", new List<IElementos> { tijera }, 100);

            // Enano ataca al elfo
            elfo.RecibirAtaque(enano);

            // Verificar vida restante del elfo
            double expectedDano = Math.Max(enano.ObtenerValorDeAtaque() - elfo.ObtenerValorDeDefensa(), 0);
            double expectedVida = 100 - expectedDano;
            Assert.That(elfo.Vida, Is.EqualTo(expectedVida));
        }

        [Test]
        public void TestElfoSeCura()
        {
            // Crear elfo con poca vida
            var elfoDebil = new Elfo("Elfo Debilucho", new List<IElementos>(), 20);

            // Elfo se cura
            elfoDebil.Curar();

            // Verificar que la vida aumentó correctamente (+10)
            Assert.That(elfoDebil.Vida, Is.EqualTo(30));
        }
    }
}