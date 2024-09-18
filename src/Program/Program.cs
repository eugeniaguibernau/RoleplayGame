using Program.Elementos;
using Program.Interfaces;

namespace Program;

public class Program
{
    static void Main(string[] args)
    {
        // Elementos
        IItemAtaque espada = new Espada("Espada", 10, 5);
        IItemAtaque arcoYFlechas = new Arco("Arco y flechas", 5);
        IItemDefensa escudo = new Escudo("Escudo", 3);
        BastonMagico bastonMagico = new BastonMagico("Bastón mágico", 15, 0, 10);

        // Personajes
        Enanos Enanito = new Enanos("Gimli", espada, escudo, 100);
        Mago Maguito = new Mago("Gandalf", bastonMagico, 80);
        Elfo Elfito = new Elfo("Legolas", arcoYFlechas, 90);

        // Detalles de los personajes
        Console.WriteLine(
            $"Enano: {Enanito.Nombre}, Vida: {Enanito.Vida}, Espada: {Enanito.Espada.Nombre}, Escudo: {Enanito.Escudo.Nombre}");
        Console.WriteLine(
            $"Mago: {Maguito.Nombre}, Vida: {Maguito.Vida}, Bastón Mágico: {Maguito.BastonMagico.Nombre}");
        Console.WriteLine(
            $"Elfo: {Elfito.Nombre}, Vida: {Elfito.Vida}, Arco: {Elfito.Arco.Nombre}");
    }
}