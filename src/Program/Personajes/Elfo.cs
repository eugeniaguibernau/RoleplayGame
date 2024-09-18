using Program.Elementos;
using Program.Interfaces;

public class Elfo : IPersonaje
{
    private string nombre;
    private double vida;
    public IItemAtaque Arco { get; set; }

    public Elfo(string nombre, IItemAtaque arco, double vida)
    {
        this.Nombre = nombre;
        this.Arco = arco;
        this.Vida = vida;
    }

    public string Nombre
    {
        get => nombre;
        set => this.nombre = value;
    }

    public double Vida
    {
        get { return vida; }
        set
        {
            if (value < 0)
            {
                vida = 0;
            }
            else if (value > 100)
            {
                vida = 100;
            }
            else
            {
                vida = value;
            }
        }
    }

    public double ObtenerValorDeAtaque()
    {
        return Arco?.Ataque ?? 0;
    }

    public double ObtenerValorDeDefensa()
    {
        return 0; // Elfo no tiene defensa por defecto
    }

    public void Curar()
    {
        Vida += 10;
        Console.WriteLine($" +10 puntos de vida. \n Salud de {Nombre}: {Vida}");
    }

    public void RecibirAtaque(IPersonaje personaje)
    {
        double dano = Math.Max(personaje.ObtenerValorDeAtaque() - ObtenerValorDeDefensa(), 0);
        Vida -= dano;
        if (Vida <= 0)
        {
            Console.WriteLine($"{Nombre} ha muerto");
        }
    }
}