using Program.Interfaces;

namespace Program.Elementos;

public class Escudo : IItemDefensa
{
    public double Defensa { get; set; }
    public string Nombre { get; set; }

    public Escudo(string nombre, double defensa)
    {
        this.Nombre = nombre;
        this.Defensa = defensa;
    }
}