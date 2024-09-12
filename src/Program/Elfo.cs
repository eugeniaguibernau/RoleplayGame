public class Elfo
{
    private string nombre;
    private double vida;
    private List<Elementos> elementos;

    public Elfo(string nombre, List<Elementos> elementos, double vida)
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

    public List<Elementos> Elementos
    {
        get => elementos;
        set => this.elementos = value;
    }

    public void RecibirAtaqueMago(Mago maguete)
    {
        Vida -= maguete.ObtenerValorDeAtaque() * this.ObtenerValorDefensa() / 100;

        if (Vida <= 0)
        {
            Console.WriteLine($"Tu Elfo, {Nombre} fue ejecutado y despedazado vilmente por {maguete.Nombre}.");
        }
    }

    public void RecibirAtaqueElfo(Elfo elfete)
    {
        Vida -= elfete.ObtenerValorDeAtaque() * this.ObtenerValorDefensa() / 100;

        if (Vida <= 0)
        {
            Console.WriteLine($"Tu Elfo, {Nombre} fue ejecutado y despedazado vilmente por {elfete.Nombre}.");
        }
    }

    public void RecibirAtaqueEnano(Enanos enanete)
    {
        Vida -= enanete.ObtenerValorDeAtaque() * this.ObtenerValorDefensa() / 100;

        if (Vida <= 0)
        {
            Console.WriteLine($"Tu Elfo, {Nombre} fue ejecutado y despedazado vilmente por {enanete.Nombre}.");
        }
    }

    public double ObtenerValorDeAtaque()
    {
        double total = 0;
        foreach (Elementos item in elementos)
        {
            total += item.Ataque;
        }

        return total;
    }

    public double ObtenerValorDefensa()
    {
        double total = 0;
        foreach (Elementos item in elementos)
        {
            total += item.Defensa;
        }

        return total;
    }

    public void Curar()
    {
        Vida += 10;
        Console.WriteLine($" +10 puntos de vida. \n Salud de {Nombre}: {Vida}");
    }

    public void AgregarElemento(Elementos item)
    {
        if (!elementos.Contains(item))
        {
            elementos.Add(item);
            Console.WriteLine($"{item.Nombre} fue agregado al inventario de {Nombre}.");
        }
    }

    public void QuitarItem(Elementos item)
    {
        if (elementos.Contains(item))
        {
            elementos.Remove(item);
            Console.WriteLine($"{item.Nombre} fue quitado del inventario de {Nombre}.");
        }
    }
}