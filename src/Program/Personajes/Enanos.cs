using Program.Elementos;
using Program.Interfaces;

public class Enanos : IPersonaje
{
    private string nombre;
    private double vida;
    public Espada Espada { get; set; }
    public Escudo Escudo { get; set; }

    public Enanos(string nombre, Espada espada, Escudo escudo, double vida)
    {
        this.Nombre = nombre;
        this.Espada = espada;
        this.Escudo = escudo;
        this.Vida = vida;
    }

    public string Nombre
    {
        get => nombre;
        set => this.nombre = value;
    }

    public double Vida
    {
        get => vida;
        set
        {
            if (value < 0)
            {
                vida = 0;
            }
            else
            {
                vida = value;
            }
        }
    }

    public double ObtenerValorDeAtaque()
    {
        return Espada?.Ataque ?? 0;
    }

    public double ObtenerValorDeDefensa()
    {
        return Escudo?.Defensa ?? 0;
    }

    public void Curar()
    {
        if (Vida + 10 <= 100)
        {
            Vida += 10;
        }
        else
        {
            Vida = 100;
        }
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