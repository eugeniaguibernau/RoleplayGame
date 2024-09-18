// src/Program/Personajes/Mago.cs

using Program.Elementos;
using Program.Interfaces;

public class Mago : IPersonaje
{
    private string nombre;
    private double vida;
    public BastonMagico BastonMagico { get; set; }

    public Mago(string nombre, BastonMagico bastonMagico, double vida)
    {
        this.Nombre = nombre;
        this.BastonMagico = bastonMagico;
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
        return BastonMagico?.Ataque ?? 0;
    }

    public double ObtenerValorDeDefensa()
    {
        return BastonMagico?.Defensa ?? 0;
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