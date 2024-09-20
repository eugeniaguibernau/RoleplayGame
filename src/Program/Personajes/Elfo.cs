using System.Numerics;
using Program.Elementos;
using Program.Interfaces;

public class Elfo : IPersonaje
{
    private string nombre;
    private double vida;
    private List<IElementos> elementos;

    //public IItemAtaque Arco { get; set; }

    public Elfo(string nombre, List<IElementos> elementos, double vida)
    {
        this.Nombre = nombre;
        this.elementos = elementos;
        //this.Arco = arco;
        this.Vida = vida;
    }

    public List<IElementos> Elementos
    {
        get => elementos;
        set => elementos = value;
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

    public void AgregarElemento(IElementos item)
    {
        elementos.Add(item);
    }

    public void QuitarElemento(IElementos item)
    {
        elementos.Remove(item);
    }
}