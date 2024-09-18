using Program.Interfaces;

namespace Program.Elementos;

public class HechizoProteccion : IHechizoDefensa
{
    public double Defensa { get; set; }
    public string Nombre { get; set; }

    public HechizoProteccion(string nombre, double defensa)
    {
        this.Nombre = nombre;
        this.Defensa = defensa;
    }
}