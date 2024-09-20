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
        var bastonMagico = new BastonMagico("Palo de madera con brillo", 30, 5, 2);

        // Personajes y agregado de elementos
        Enanos Enanito = new Enanos("Gimli", new List<IElementos>(), 100);
        Mago Maguito = new Mago("Gandalf", new List<IElementos>(), new List<IHechizo>(), 80);
        Elfo Elfito = new Elfo("Legolas", new List<IElementos>(), 90);
        Elfito.AgregarElemento(espada);
        Enanito.AgregarElemento(escudo);
        Enanito.AgregarElemento(arcoYFlechas);
        Maguito.AgregarHechizo(bastonMagico);

        string enanoItems = string.Join(", ", Enanito.Elementos.Select(e => e.Nombre));
        string magoItems = string.Join(", ", Maguito.Elementos.Select(e => e.Nombre));
        string magoHechizos = string.Join(", ", Maguito.Hechizos.Select(h => h.Nombre));
        string elfoItems = string.Join(", ", Elfito.Elementos.Select(e => e.Nombre));

        Console.WriteLine($"Enano: {Enanito.Nombre}, Vida: {Enanito.Vida}, Items: {enanoItems}");
        Console.WriteLine(
            $"Mago: {Maguito.Nombre}, Vida: {Maguito.Vida}, Items: {magoItems}, Hechizos: {magoHechizos}");
        Console.WriteLine($"Elfo: {Elfito.Nombre}, Vida: {Elfito.Vida}, Arco: {elfoItems}");
    }
}