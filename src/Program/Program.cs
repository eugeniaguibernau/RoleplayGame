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

        // Personajes y agregado de elementos
        Enanos Enanito = new Enanos("Gimli", 100);
        Mago Maguito = new Mago("Gandalf", 80);
        Elfo Elfito = new Elfo("Legolas", 90);
        Elfito.AgregarElemento(espada);
        Enanito.AgregarElemento(escudo);
        Enanito.AgregarElemento(arcoYFlechas);
        Maguito.AgregarElemento(bastonMagico);
        
        

        // Detalles de los personajes
        Console.WriteLine(
            $"Enano: {Enanito.Nombre}, Vida: {Enanito.Vida}, Items: {Enanito.Elementos}");
        Console.WriteLine(
            $"Mago: {Maguito.Nombre}, Vida: {Maguito.Vida}, Bastón Mágico: {Maguito.Elementos}");
        Console.WriteLine(
            $"Elfo: {Elfito.Nombre}, Vida: {Elfito.Vida}, Arco: {Elfito.Elementos}");
    }
}