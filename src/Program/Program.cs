namespace Program;

public class Program
{
    static void Main(string[] args)
    {
        //Elementos
        Elementos espada = new Elementos("Espada", 10, 5, "Espadas");
        Elementos arcoYFlechas = new Elementos("Arco y flechas", 5, 1, "Varios");
        Elementos bastonMagico = new Elementos("Bastón Mágico", 3, 10, "Mágicos");

        // Hechizos
        Hechizos bolaDeFuego = new Hechizos("Bola de Fuego", 15, 0, "Ofensivo");
        Hechizos escudoMagico = new Hechizos("Escudo Mágico", 0, 10, "Defensivo");

        // Personajes
        Enanos Enanito = new Enanos("Gimli", new List<Elementos> { espada }, 100);
        Mago Maguito = new Mago("Gandalf", new List<Elementos> { bastonMagico },
            new List<Hechizos> { bolaDeFuego, escudoMagico }, 80);
        Elfo Elfito = new Elfo("Legolas", new List<Elementos> { arcoYFlechas }, 90);

        // Detalles de los personajes
        Console.WriteLine(
            $"Enano: {Enanito.Nombre}, Vida: {Enanito.Vida}, Elementos: {string.Join(", ", Enanito.Elementos.Select(e => e.Nombre))}");
        Console.WriteLine(
            $"Mago: {Maguito.Nombre}, Vida: {Maguito.Vida}, Elementos: {string.Join(", ", Maguito.Elementos.Select(e => e.Nombre))}, Hechizos: {string.Join(", ", Maguito.LibroDeHechizos.Select(h => h.Nombre))}");
        Console.WriteLine(
            $"Elfo: {Elfito.Nombre}, Vida: {Elfito.Vida}, Elementos: {string.Join(", ", Elfito.Elementos.Select(e => e.Nombre))}");
    }
}