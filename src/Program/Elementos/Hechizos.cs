public class Hechizos : IElemento
{
    private string nombre;
    private double ataque;
    private double defensa;
    private string tipo;

    public Hechizos(string nombre, double ataque, double defensa, string tipo)
    {
        this.Nombre = nombre;
        this.Ataque = ataque;
        this.Defensa = defensa;
        this.Tipo = tipo;
    }

    public string Nombre
    {
        get => nombre;
        set => nombre = value;
    }

    public double Ataque
    {
        get => ataque;
        set => ataque = value;
    }

    public double Defensa
    {
        get => defensa;
        set => defensa = value;
    }

    public string Tipo
    {
        get => tipo;
        set => tipo = value;
    }
}