namespace Program;

public class Elfo
{
    private string nombre;
    public string Nombre { get => nombre; set => this.nombre = value; }

    private List<Elementos> listaItems = new List<Elementos>();
    
    private double vida = 100;
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

    public Elfo(string nombre, double vida)
    {
        this.Nombre = nombre;
        this.Vida = vida;
    }

    public void RecibirAtaqueMago(Mago maguete)
    {
            Vida -= maguete.ObtenerValorDeAtaque() * this.ObtenerValorDefensa()/100;

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

    public void RecibirAtaqueEnano(Enano enanete)
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
        foreach (Elemento item in listaItems)
        {
            total += item.Ataque;
        }

        return total;
    }
    public double ObtenerValorDefensa()
    {
        double total = 0;
        foreach (Elemento item in listaItems)
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

    public void AgregarItem(Elemento item)
    {
        if (!listaItems.Contains(item))
        {
            listaItems.Add(item);
            Console.WriteLine($"{item.Nombre} fue agregado al inventario de {Nombre}.");
        }
        
    }

    public void QuitarItem(Elemento item)
    {
        if (listaItems.Contains(item))
        {
            listaItems.Remove(item);
            Console.WriteLine($"{item.Nombre} fue quitado del inventario de {Nombre}.");
        }
    }
}