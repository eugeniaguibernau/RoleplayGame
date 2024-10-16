using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Program.Tests
{
    public class TestBatalla
    {
        [Test]
        public void Test_HeroesRecibenAtaquesCorrectamente()
        {
            // Defino como los heroes al mago y al duende con lanza en esta ocacion, y de enemigo creo uno generico.
            var mago = new Mago("Hugo", new List<IElementos>(), new List<IHechizo>(), 100);  
            var enanoHeroe = new Enano("Duende con lanza", 80);  
            var enemigo = new EnemigoGenerico("Shrek", 30, 10); // Enemigo genérico (Shrek) con 30 de vida y 10 de ataque.

            var heroes = new List<IPersonaje> { mago, enanoHeroe };
            var enemigos = new List<EnemigoGenerico> { enemigo };

            var batalla = new Batalla(heroes, enemigos);

            // En esta fase de la batalla solo ataca Shrek.
            batalla.DoEncounter();

            // Verifico que los heroes hayan recibido la golpiza.
            Assert.Less(mago.Vida, 100, "El Mago no recibió el ataque correctamente.");
            Assert.Less(enanoHeroe.Vida, 80, "El Enano héroe no recibió el ataque correctamente.");
        }

        [Test]
        public void Test_HeroesDerrotanEnemigos()
        {
            var mago = new Mago("Hugo", new List<IElementos>(), new List<IHechizo>(), 100); 
            var enano = new Enano("Duende con lanza", 80);   
            var enemigo = new EnemigoGenerico("Shrek", 30, 10); 

            var heroes = new List<IPersonaje> { mago, enanoHeroe };
            var enemigos = new List<EnemigoGenerico> { enemigo };

            var batalla = new Batalla(heroes, enemigos);

            // Se ejecuta la batalla
            batalla.DoEncounter();

            // Verifico que los heroes hayan derrotado al malvado Shrek
            Assert.AreEqual(0, enemigos.Count(e => e.Vida > 0), "No todos los enemigos fueron derrotados.");
        }

        [Test]
        public void Test_HeroesSeCuranConVPAlto()
        {
            // Creamos un Mago con suficiente VP para curarse.
            var mago = new Mago("Hugo", new List<IElementos>(), new List<IHechizo>(), 50); // Hugo con 50 de vida.
            var enemigo = new EnemigoGenerico("Shrek", 30, 10); 
            var heroes = new List<IPersonaje> { mago };
            var enemigos = new List<EnemigoGenerico> { enemigo };

            // Simulamos que el Mago tiene 5 puntos de victoria
            mago.VP = 5; // Damos al mago 5 puntos de victoria

            var batalla = new Batalla(heroes, enemigos);

            // Se ejecuta el batallon.
            batalla.DoEncounter();

            // Assert: Verificamos que el mago se curó
            Assert.Greater(mago.Vida, 50, "El mago no se curó correctamente.");
        }
    }

    // Clase de enemigo genérico (Esto despues cuando tengamos definido a los malos se saca)
    public class EnemigoGenerico : IPersonaje
    {
        public string Nombre { get; private set; }
        public int Vida { get; private set; }
        public int Ataque { get; private set; }
        public int VP { get; set; }

        public EnemigoGenerico(string nombre, int vida, int ataque)
        {
            Nombre = nombre;
            Vida = vida;
            Ataque = ataque;
        }

        public void RecibirAtaque(IPersonaje atacante)
        {
            // El enemigo pierde vida cuando recibe un ataque
            Vida -= atacante.AtaqueTotal();
            if (Vida < 0) Vida = 0; // La vida no puede ser negativa
        }

        public void Curar()
        {
            // No tiene sentido, lo se, puesto a que no se curan los malos, pero aun no tenemos las clases especificas heroe y villano.
        }

        public void ObtenerVP(IPersonaje enemigo)
        {
            // Los enemigos no ganan VP, esta función no se usa aquí.
        }

        public int AtaqueTotal()
        {
            return Ataque;
        }
    }

    
}
