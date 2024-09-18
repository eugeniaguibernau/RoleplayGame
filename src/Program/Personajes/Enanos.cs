using Program.Elementos;
using Program.Interfaces;

public class Enanos : IPersonaje
{
    private string nombre;
    private double vida;
    private List<IElementos> elementos;
   //public IItemAtaque Espada { get; set; }

    //public IItemDefensa Escudo { get; set; }


    public Enanos(string nombre, List<IElementos> elementos, double vida)
    {
        this.Nombre = nombre;
        this.elementos = elementos;
        //this.Espada = espada;
        //this.Escudo = escudo;
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
        double tot = 0;
        foreach (IElementos elemento in elementos)
        {
            if (elemento is IItemAtaque ataqueElemento)
            {
                tot += ataqueElemento.Ataque;
            }
        }
        return tot;
    }

    public double ObtenerValorDeDefensa()
    {
        double tot = 0;
        foreach (IElementos elemento in elementos)
        {
            if (elemento is IItemDefensa defensaElemento)
            {
                tot += defensaElemento.Defensa;
            }
        }
        return tot;
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