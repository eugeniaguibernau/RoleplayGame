namespace Program;

public class Program
{
    static void Main(string[] args)
    {
        Elementos espada = new Elementos("Espada", 10, 5, "Espadas");
        Elementos arcoYFlechas = new Elementos("Arco y flechas", 5, 1, "Varios");
        Enanos Enanito = new Enanos("Enanito1", new List<Elementos> { espada, arcoYFlechas }, 100);
        
    }

}