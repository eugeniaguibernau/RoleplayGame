using Program.Interfaces;

namespace Program.Elementos;

public class BastonMagico : IHechizoAtaque, IHechizoDefensa
{
    public string Nombre { get; set; }
    public double Ataque { get; set; }
    public double Defensa { get; set; }

    public int MultiplicadorDanio { get; set; }

    public BastonMagico(string nombre, double ataque, double defensa, int multiplicadorDanio)
    {
        this.Nombre = nombre;
        this.Ataque = ataque;
        this.Defensa = defensa;
        this.MultiplicadorDanio = multiplicadorDanio;
    }
}