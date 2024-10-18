using Program.Elementos;
using Program.Interfaces;
using Program.Personajes;

namespace LibraryTests
{
    public class BatallaTests
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
            mago = new Mago("Hugo", new List<IElementos> { arco }, new List<IHechizo> { hechizoparamago }, 100);
            enano = new Enanos("Gaspar", new List<IElementos> { escudo, tijera }, 120);

            enemigo1 = new Enemigo("Enemigo1", 100, new List<IElementos> { arco }, 10);
            enemigo2 = new Enemigo("Enemigo2", 100, new List<IElementos> { escudo }, 10);

            heroes = new List<Heroe> { mago, enano };
            enemigos = new List<Enemigo> { enemigo1, enemigo2 };

            batalla = new Batalla(heroes, enemigos);

            arco = new Arco("arco", 10);
            escudo = new Escudo("escudo", 5);
            hechizoparamago = new HechizoProteccion("proteger", 10);
            tijera = new Tijera("ijera", 5, 10);
        }

        [Test]
        public void TestHeroesGananBatalla()
        {
            // Crear héroes y enemigos
            var espada = new Espada("Espada", 10, 5);
            var heroe1 = new HeroeConcreto("Heroe 1", 30, new List<IElementos> { espada });
            var heroe2 = new HeroeConcreto("Heroe 2", 30, new List<IElementos> { espada });

            var enemigo1 = new Enemigo("Enemigo 1", 25, new List<IElementos> { new Espada("Espada del enemigo", 8, 3) },
                3);
            var enemigo2 = new Enemigo("Enemigo 2", 25, new List<IElementos> { new Espada("Espada del enemigo", 8, 3) },
                3);

            // Iniciar batalla
            var batalla = new Batalla(new List<Heroe> { heroe1, heroe2 }, new List<Enemigo> { enemigo1, enemigo2 });
            batalla.DoEncounter();

            // Verificar que los héroes ganaron
            Assert.That(heroe1.Vida, Is.GreaterThan(0));
            Assert.That(heroe2.Vida, Is.GreaterThan(0));
            Assert.That(enemigo1.Vida, Is.EqualTo(0));
            Assert.That(enemigo2.Vida, Is.EqualTo(0));
        }

        [Test]
        public void TestEnemigosGananBatalla()
        {
            // Crear héroes y enemigos
            var heroe1 = new HeroeConcreto("Heroe 1", 10, new List<IElementos>());
            var heroe2 = new HeroeConcreto("Heroe 2", 10, new List<IElementos>());

            var enemigo1 = new Enemigo("Enemigo 1", 25, new List<IElementos> { new Espada("Espada del enemigo", 8, 3) },
                3);
            var enemigo2 = new Enemigo("Enemigo 2", 25, new List<IElementos> { new Espada("Espada del enemigo", 8, 3) },
                3);

            // Iniciar batalla
            var batalla = new Batalla(new List<Heroe> { heroe1, heroe2 }, new List<Enemigo> { enemigo1, enemigo2 });
            batalla.DoEncounter();

            // Verificar que los enemigos ganaron
            Assert.That(heroe1.Vida, Is.EqualTo(0));
            Assert.That(heroe2.Vida, Is.EqualTo(0));
            Assert.That(enemigo1.Vida, Is.GreaterThan(0));
            Assert.That(enemigo2.Vida, Is.GreaterThan(0));
        }

        [Test]
        public void TestRemoverHeroesDerrotados()
        {
            // Crear héroes
            var heroe1 = new HeroeConcreto("Heroe 1", 0, new List<IElementos>());
            var heroe2 = new HeroeConcreto("Heroe 2", 30, new List<IElementos>());

            // Iniciar batalla
            var batalla = new Batalla(new List<Heroe> { heroe1, heroe2 }, new List<Enemigo>());
            batalla.RemoverHeroesDerrotados();

            // Verificar que el héroe derrotado ha sido removido
            Assert.That(batalla.Heroes.Count, Is.EqualTo(1));
            Assert.That(batalla.Heroes[0].Nombre, Is.EqualTo("Heroe 2"));
        }

        [Test]
        public void TestRemoverEnemigosDerrotados()
        {
            // Crear enemigos
            var enemigo1 = new Enemigo("Enemigo 1", 0, new List<IElementos>(), 0);
            var enemigo2 = new Enemigo("Enemigo 2", 25, new List<IElementos>(), 3);

            // Iniciar batalla
            var batalla = new Batalla(new List<Heroe>(), new List<Enemigo> { enemigo1, enemigo2 });
            batalla.RemoverEnemigosDerrotados();

            // Verificar que el enemigo derrotado ha sido removido
            Assert.That(batalla.Enemigos.Count, Is.EqualTo(1));
            Assert.That(batalla.Enemigos[0].Nombre, Is.EqualTo("Enemigo 2"));
        }

        [Test]
        public void TestCurarHeroesConVpAlto()
        {
            // Crear héroes
            var espada = new Espada("Espada", 10, 5);
            var heroe1 = new HeroeConcreto("Heroe 1", 10, new List<IElementos> { espada }) { VP = 5 };
            var heroe2 = new HeroeConcreto("Heroe 2", 10, new List<IElementos> { espada }) { VP = 3 };

            // Iniciar batalla
            var batalla = new Batalla(new List<Heroe> { heroe1, heroe2 }, new List<Enemigo>());
            batalla.CurarHeroesConVpAlto();

            // Verificar que el héroe con VP alto se curó
            Assert.That(heroe1.Vida, Is.EqualTo(20)); // Aumenta la vida al curarse
            Assert.That(heroe2.Vida, Is.EqualTo(10)); // No se cura porque VP < 5
        }

        [Test]
        public void TestFaseAtaqueHeroesYRemoverEnemigosDerrotados()
        {
            // Crear héroes y enemigos
            var espada = new Espada("Espada", 18, 5); // 18 de ataque
            var heroe = new HeroeConcreto("Heroe", 30, new List<IElementos> { espada });

            var enemigo = new Enemigo("Enemigo", 14, new List<IElementos> { new Espada("Espada del enemigo", 8, 3) },
                3);

            // Iniciar batalla
            var batalla = new Batalla(new List<Heroe> { heroe }, new List<Enemigo> { enemigo });

            // Realizar ataque de héroes
            batalla.FaseAtaqueHeroes();

            // Verificar que el enemigo fue derrotado
            Assert.That(enemigo.Vida, Is.EqualTo(0));
            Assert.That(batalla.Enemigos.Count, Is.EqualTo(0)); // Asegurarse de que se removió
        }


        public class HeroeConcreto : Heroe
        {
            public HeroeConcreto(string nombre, double vida, List<IElementos> elementos)
            {
                Nombre = nombre;
                Vida = vida;
                this.elementos = elementos;
                this.vP = 0; // Inicializar VP en 0
            }
        }
    }
}