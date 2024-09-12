public class Mago
{
    private string nombre;
    private double vida;
    private List<Elementos> elementos;
    private List<Hechizos> libroDeHechizos;

    public Mago(string nombre, List<Elementos> elementos, List<Hechizos> libroDeHechizos, double vida)
    {
        this.nombre = nombre;
        this.elementos = elementos ?? new List<Elementos>();
        this.vida = vida;
        this.libroDeHechizos = libroDeHechizos ?? new List<Hechizos>();
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

    public List<Elementos> Elementos
    {
        get => elementos;
        set => elementos = value;
    }

    public List<Hechizos> LibroDeHechizos
    {
        get => libroDeHechizos;
        set => libroDeHechizos = value;
    }

    public double ObtenerValorDefensa()
    {
        double defensa = 0;
        foreach (Elementos item in elementos)
        {
            defensa += item.Defensa;
        }

        return defensa;
    }

    public void RecibirAtaqueEnano(Enanos enano)
    {
        Vida -= enano.ObtenerValorDeAtaque() * this.ObtenerValorDefensa() / 100;
        if (Vida <= 0)
        {
            Vida = 0;
            Console.WriteLine(
                $"Tu mago {Nombre} ha recibido {enano.ObtenerValorDeAtaque()} puntos de damage y ha muerto.");
        }
        else
        {
            Console.WriteLine(
                $"Tu mago {Nombre} ha recibido {enano.ObtenerValorDeAtaque()} puntos de damage y le quedan {Vida} puntos de vida. Ojo con Gaspar!");
        }
    }

    public void RecibirAtaqueElfo(Elfo elfo)
    {
        Vida -= elfo.ObtenerValorDeAtaque() * this.ObtenerValorDefensa() / 100;
        if (Vida <= 0)
        {
            Vida = 0;
            Console.WriteLine(
                $"Tu mago {Nombre} ha recibido {elfo.ObtenerValorDeAtaque()} puntos de damage y ha muerto.");
        }
        else
        {
            Console.WriteLine(
                $"Tu mago {Nombre} ha recibido {elfo.ObtenerValorDeAtaque()} puntos de damage y le quedan {Vida} puntos de vida. Ojo con Gaspar!");
        }
    }

    public void RecibirAtaqueMago(Mago mago)
    {
        Vida -= mago.ObtenerValorDeAtaque() * this.ObtenerValorDefensa() / 100;
        if (Vida <= 0)
        {
            Vida = 0;
            Console.WriteLine(
                $"Tu mago {Nombre} ha recibido {mago.ObtenerValorDeAtaque()} puntos de damage y ha muerto.");
        }
        else
        {
            Console.WriteLine(
                $"Tu mago {Nombre} ha recibido {mago.ObtenerValorDeAtaque()} puntos de damage y le quedan {Vida} puntos de vida. Ojo con Gaspar!");
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

    public double ObtenerValorDeAtaque()
    {
        double poderItems = 0;
        foreach (Elementos item in elementos)
        {
            poderItems += item.Ataque;
        }

        double poderHechizos = 0;
        foreach (Hechizos hechizo in libroDeHechizos)
        {
            poderHechizos += hechizo.Ataque;
        }

        return poderItems + poderHechizos;
    }

    public void AgregarElemento(Elementos elemento)
    {
        elementos.Add(elemento);
    }

    public void QuitarElemento(Elementos elemento)
    {
        elementos.Remove(elemento);
    }
}