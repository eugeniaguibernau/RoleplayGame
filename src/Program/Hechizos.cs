public class Hechizos
{
    private string nombre;
    private double ataque;
    private double defensa;
    private string tipo;

    public Hechizos(string nombre, double ataque, double defensa, string tipo)
    {
        this.nombre = nombre;
        this.ataque = ataque;
        this.defensa = defensa;
        this.tipo = tipo;
    }

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public double Ataque
    {
        get { return ataque; }
        set { ataque = value; }
    }

    public double Defensa
    {
        get { return defensa; }
        set { defensa = value; }
    }

    public string Tipo
    {
        get { return tipo; }
        set { tipo = value; }
    }
}