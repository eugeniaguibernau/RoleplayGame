using Program.Elementos;
using Program.Interfaces;

namespace LibraryTests
{
    public class MagoTests
    {
        [Test]
        public void TestObtenerValorAtaque()
        {
            // Crear items de ataque
            var bastonMagico = new BastonMagico("Bastón Mágico", 20, 5, 2);

            // Crear mago y agregar elementos de ataque
            var mago = new Mago("Mago Poderoso", new List<IElementos>(), new List<IHechizo> (), 100);
            mago.AgregarElemento(bastonMagico);

            // Verificar que el ataque total es la suma correcta
            Assert.That(mago.ObtenerValorDeAtaque(), Is.EqualTo(40));
        }

        [Test]
        public void TestObtenerValorDefensa()
        {
            // Crear items de defensa
            var escudoMagico = new EscudoMagico("Escudo Mágico", 10, 10);

            // Crear mago y agregar elementos de defensa
            var mago = new Mago("Mago Defensor", new List<IElementos>(), new List<IHechizo> { escudoMagico }, 100);

            // Verificar que la defensa total es la suma correcta
            Assert.That(mago.ObtenerValorDeDefensa(), Is.EqualTo(10));
        }

        [Test]
        public void TestMagoAtacaMago()
        {
            // Crear mago atacante
            var bastonMagico = new BastonMagico("Varita", 25, 0, 2);
            var magoAtacante = new Mago("Mago Atacante", new List<IElementos>{bastonMagico}, new List<IHechizo> (),
                100);

            // Crear mago defensor
            var escudoMagico = new EscudoMagico("Escudo Mágico", 10, 3);
            var magoDefensor = new Mago("Mago Defensor", new List<IElementos>(), new List<IHechizo> { escudoMagico },
                100);

            // Mago atacante ataca al mago defensor
            magoDefensor.RecibirAtaque(magoAtacante);

            // Verificar vida restante
            double expectedDano =
                Math.Max(magoAtacante.ObtenerValorDeAtaque() - magoDefensor.ObtenerValorDeDefensa(), 0);
            double expectedVida = 100 - expectedDano;
            Assert.That(magoDefensor.Vida, Is.EqualTo(expectedVida));
        }

        [Test]
        public void TestElfoAtacaMago()
        {
            // Crear mago
            var escudoMagico = new EscudoMagico("Escudo Mágico", 10, 5);
            var mago = new Mago("Mago Defensor", new List<IElementos>(), new List<IHechizo> { escudoMagico }, 100);

            // Crear elfo atacante
            var espada = new Espada("Espada Élfica", 30, 5);
            var elfoAtacante = new Elfo("Elfo Atacante", new List<IElementos> { espada }, 100);

            // Elfo ataca al mago
            mago.RecibirAtaque(elfoAtacante);

            // Verificar vida restante del mago
            double expectedDano = Math.Max(elfoAtacante.ObtenerValorDeAtaque() - mago.ObtenerValorDeDefensa(), 0);
            double expectedVida = 100 - expectedDano;
            Assert.That(mago.Vida, Is.EqualTo(expectedVida));
        }

        [Test]
        public void TestMagoSeCura()
        {
            // Crear mago con poca vida
            var magoDebil = new Mago("Mago Débil", new List<IElementos>(), new List<IHechizo>(), 10);

            // Mago se cura
            magoDebil.Curar();

            // Verificar que la vida aumentó correctamente (+10)
            Assert.That(magoDebil.Vida, Is.EqualTo(20));
        }
    }
}