public class Enanos
{
    private string nombre;
    private List<Elementos> elementos;
    private double vida;

    public Enanos(string nombre, List<Elementos> elementos, double vida)
    {
        this.Nombre = nombre;
        this.Elementos = elementos;
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

    public List<Elementos> Elementos
    {
        get => elementos;
        set => this.elementos = value;
    }

    public double ObtenerValorDeAtaque()
    {
        double valorAtaque = 0;
        foreach (Elementos elemento in elementos)
        {
            valorAtaque += elemento.Ataque;
        }

        return valorAtaque;
    }

    public double ObtenerValorDeDefensa()
    {
        double valorDefensa = 0;
        foreach (Elementos elemento in elementos)
        {
            valorDefensa += elemento.Defensa;
        }

        return valorDefensa;
    }

    public void AgregarElemento(Elementos elemento)
    {
        if (!elementos.Contains(elemento))
        {
            elementos.Add(elemento);
        }
    }

    public void QuitarElemento(Elementos elemento)
    {
        if (elementos.Contains(elemento))
        {
            elementos.Remove(elemento);
        }
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

    public void RecibirAtaqueDeEnano(Enanos enano)
    {
        double dano = Math.Max(enano.ObtenerValorDeAtaque() - ObtenerValorDeDefensa(), 0);
        Vida -= dano;
        if (Vida <= 0)
        {
            Console.WriteLine($"{Nombre} ha muerto");
        }
    }

    public void RecibirAtaqueDeElfo(Elfo elfo)
    {
        double dano = Math.Max(elfo.ObtenerValorDeAtaque() - ObtenerValorDeDefensa(), 0);
        Vida -= dano;
        if (Vida <= 0)
        {
            Console.WriteLine($"{Nombre} ha muerto");
        }
    }

    public void RecibirAtaqueDeMago(Mago mago)
    {
        double dano = Math.Max(mago.ObtenerValorDeAtaque() - ObtenerValorDeDefensa(), 0);
        Vida -= dano;
        if (Vida <= 0)
        {
            Console.WriteLine($"{Nombre} ha muerto");
        }
    }
}