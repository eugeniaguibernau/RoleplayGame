using Program.Elementos;
using Program.Interfaces;
using Program.Personajes;

namespace Program.Tests
{
    [TestFixture]
    public class BatallaTest
    {
        private Mago mago;
        private Enanos enano;
        private Enemigo enemigo1;
        private Enemigo enemigo2;
        private List<Heroe> heroes;
        private List<Enemigo> enemigos;
        private Batalla batalla;
        private Arco arco;
        private Escudo escudo;
        private HechizoProteccion hechizoparamago;
        private Tijera tijera;

        [SetUp]
        public void Setup()
        {
            mago = new Mago("Hugo", new List<IElementos>{arco}, new List<IHechizo>{hechizoparamago}, 100);
            enano = new Enanos("Gaspar", new List<IElementos>{escudo, tijera}, 120);
            enemigo1 = new Enemigo() { Nombre = "Opel Reckord", Vida = 80, VP = 3 };
            enemigo2 = new Enemigo() { Nombre = "Urbano", Vida = 100, VP = 5 };

            heroes = new List<Heroe> { mago, enano };
            enemigos = new List<Enemigo> { enemigo1, enemigo2 };

            batalla = new Batalla(heroes, enemigos);

            arco = new Arco("arco", 10);
            escudo = new Escudo("escudo", 5);
            hechizoparamago = new HechizoProteccion("proteger", 10);
            tijera = new Tijera("ijera", 5, 10);
        }

        [Test]
        public void TestBatalla_HeroesGanan()
        {
            batalla.DoEncounter();

            // Para asegurarse de que los buenos ganan, vemos si todos los malos fueron derrotados.
            Assert.IsEmpty(enemigos, "Los enemigos deberían estar vacíos al final de la batalla.");
            Assert.IsNotEmpty(heroes, "Debería haber al menos un héroe vivo.");
        }

        [Test]
        public void TestBatalla_EnemigosGanan()
        {
            mago.Vida = 10;
            enano.Vida = 10;

            batalla.DoEncounter();

            // Caso contrario, aqui ganan los malos, ergo; vemos si los buenos fueron derrotados.
            Assert.IsEmpty(heroes, "Los héroes deberían estar vacíos al final de la batalla.");
            Assert.IsNotEmpty(enemigos, "Debería haber al menos un enemigo vivo.");
        }

        [Test]
        public void TestHeroe_CurarConVP()
        {
            // Incrementar el VP del héroe para forzar la curación
            enano.ObtenerVP(enemigo1);
            enano.ObtenerVP(enemigo2);

            double vidaAntes = enano.Vida;
            batalla.DoEncounter(); // Debería activar la curación

            // Verificar que el enano Gaspar haya sido curado
            Assert.Greater(enano.Vida, vidaAntes, "El héroe debería haber sido curado.");
        }

        [Test]
        public void TestEnemigos_AtaqueEnCadena()
        {
            // Simular fase de ataque de enemigos
            batalla.DoEncounter();

            // Verificar que los héroes hayan recibido daño
            Assert.Less(mago.Vida, 100, "El mago debería haber recibido daño.");
            Assert.Less(enano.Vida, 120, "El enano debería haber recibido daño.");
        }

        [Test]
        public void TestRemoverHeroesDerrotados()
        {
            mago.Vida = 0;
            enano.Vida = 5;

            batalla.RemoverHeroesDerrotados();

            // Verificar que el mago Hugo ha sido eliminado, pero el enano no (porque su vida es mayor que 0)
            Assert.AreEqual(1, heroes.Count, "Debería haber solo un héroe vivo.");
            Assert.IsTrue(heroes.Contains(enano), "El enano debería seguir en la lista.");
            Assert.IsFalse(heroes.Contains(mago), "El mago debería haber sido eliminado.");
        }

        [Test]
        public void TestRemoverEnemigosDerrotados()
        {
            enemigo1.Vida = 0;
            enemigo2.Vida = 50;

            batalla.RemoverEnemigosDerrotados();

            // Verificar que el Opel Reckord ha sido eliminado, pero Urbano no (porque su vida es mayor que 0)
            Assert.AreEqual(1, enemigos.Count, "Debería haber solo un enemigo vivo.");
            Assert.IsTrue(enemigos.Contains(enemigo2), "El enemigo 2 debería seguir en la lista.");
            Assert.IsFalse(enemigos.Contains(enemigo1), "El enemigo 1 debería haber sido eliminado.");
        }


        [Test]
        public void TestBatalla_Termina()
        {
            // Verificar que el mensaje de finalización de batalla se muestra correctamente
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                batalla.DoEncounter();
                string expected = "La batalla ha terminado";

                Assert.IsTrue(sw.ToString().Contains(expected), "La batalla debería terminar con el mensaje esperado.");
            }
        }
    }
}