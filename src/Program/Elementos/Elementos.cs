public class Elementos : IElementos
{
    private string nombre;
    private double ataque;
    private double defensa;

    public Elementos(string nombre, double ataque, double defensa)
    {
        this.Nombre = nombre;
        this.Ataque = ataque;
        this.Defensa = defensa;
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
}