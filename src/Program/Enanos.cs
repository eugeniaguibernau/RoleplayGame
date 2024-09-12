public class Enanos
{
    private string nombre;
    private List<Elementos> elementos;
    private double vida;

    //Constructor
    public Enanos(string nombre, List<Elementos> elementos, double vida)
    {
        this.nombre = nombre;
        this.elementos = elementos;
        this.vida = vida;
    }

    public string Nombre
    {
        get => nombre;
    }

    public double Vida
    {
        get => vida;
        set //Para que la vida nunca quede negativa con los ataques
        {
            if (vida >= 0)
            {
                vida = value;
            }
            else
            {
                vida = 0;
            }
        }
    }

    //Obtener valor total de ataque
    public double ObtenerValorDeAtaque()
    {
        double valorAtaque = 0;
        foreach (Elementos elemento in elementos)
        {
            valorAtaque += elemento.Ataque;
        }

        return valorAtaque;
    }

    //Obtener valor total de defensa
    public double ObtenerValorDeDefensa()
    {
        double valorDefensa = 0;
        foreach (Elementos elemento in elementos)
        {
            valorDefensa += elemento.Defensa;
        }

        return valorDefensa;
    }

    //Agregar un elemento a la lista de elementos
    public void AgregarElemento(Elementos elemento)
    {
        elementos.Add(elemento);
    }

    //Sacar un elemento de la lista de elementos
    public void QuitarElemento(Elementos elemento)
    {
        elementos.Remove(elemento);
    }

    //Personaje se cura a si mismo (se aumenta 10 puntos de vida)
    public void Curar()
    {
        if (Vida + 10 <= 100)
        {
            vida += 10;
        }
        else
        {
            vida = 100;
        }
    }

    //Recibir ataques (de otros enanos, de un elfo o de un mago)
    public void RecibirAtaqueDeEnano(Enanos enano)
    {
        Vida -= enano.ObtenerValorDeAtaque() * this.ObtenerValorDeDefensa() / 100;
        if (Vida <= 0)
        {
            Console.WriteLine($"{nombre} ha muerto");
        }
    }

    public void RecibirAtaqueDeElfo(Elfo elfo)
    {
        Vida -= elfo.ObtenerValorDeAtaque() * this.ObtenerValorDeDefensa() / 100;
        if (Vida <= 0)
        {
            Console.WriteLine($"{nombre} ha muerto");
        }
    }

    public void RecibirAtaqueDeMago(Mago mago)
    {
        Vida -= mago.ObtenerValorDeAtaque() * this.ObtenerValorDeDefensa() / 100;
        Vida += (this.ObtenerValorDeDefensa() / 100);
        if (Vida <= 0)
        {
            Console.WriteLine($"{nombre} ha muerto");
        }
    }
}