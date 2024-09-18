using Program.Interfaces;

namespace Program.Elementos;

public class Arco : IItemAtaque
{
    public double Ataque { get; set; }
    public string Nombre { get; set; }

    public Arco(string nombre, double ataque)
    {
        this.Nombre = nombre;
        this.Ataque = ataque;
    }
}