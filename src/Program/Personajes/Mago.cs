using Program.Interfaces;

public class Mago : IPersonaje
{
    private string nombre;
    private double vida;
    private List<IElementos> elementos;
    private List<IHechizo> hechizos;

    public Mago(string nombre, List<IElementos> elementos, List<IHechizo> hechizos, double vida)
    {
        this.nombre = nombre;
        this.elementos = elementos ?? new List<IElementos>();
        this.hechizos = hechizos ?? new List<IHechizo>();
        this.vida = vida;
    }

    public string Nombre
    {
        get => nombre;
        set => nombre = value;
    }

    public double Vida
    {
        get => vida;
        set => vida = value;
    }

    public List<IElementos> Elementos
    {
        get => elementos;
        set => elementos = value;
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
        foreach (IHechizo elemento in hechizos)
        {
            if (elemento is IHeshizoAtaque ataqueHechizo)
            {
                tot += ataqueHechizo.Ataque;
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
        foreach (IHechizo elemento in hechizos)
        {
            if (elemento is IHechizoDefensa defensaHechizo)
            {
                tot += defensaHechizo.Defensa;
            }
            
        }
        return tot;
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

    public void Curar()
    {
        if (Vida > 0)
        {
            Vida += 15;
            Console.WriteLine($"{Nombre} ha recuperado {15} puntos de salud. Enhorabuena!, pero ojito con Gaspar!");
        }
        else
        {
            Console.WriteLine($"No puedes curarte, pues ya tienes mucha vida.");
        }
    }

    
    public void AgregarElemento(IElementos elemento)
    {
        elementos.Add(elemento);
    }

    public void QuitarElemento(IElementos elemento)
    {
        elementos.Remove(elemento);
    }
}