using Program.Interfaces;

namespace Program.Elementos;

public class HechizoDeAtaque : IHechizoAtaque
{
    public double Ataque { get; set; }
    public string Nombre { get; set; }

    public HechizoDeAtaque(string nombre, double ataque)
    {
        this.Nombre = nombre;
        this.Ataque = ataque;
    }
}