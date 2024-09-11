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
            if (value > vida)
            {
                vida = 0;
            }
            vida = value;
        }
    }

    public Elfo(string nombre, double vida)
    {
        this.Nombre = nombre;
        this.Vida = vida;
    }

    public void RecibirAtaqueMago(Mago maguete)
    {
            vida -= maguete.ObtenerValorDeAtaque() * this.ObtenerValorDefensa()/100;

            if (this.vida <= 0)
            {
                Console.WriteLine($"Tu Elfo, {Nombre} fue ejecutado y despedazado vilmente por {maguete.Nombre}.");
            }
    }

    public void RecibirAtaqueElfo(Elfo elfete)
    {
        vida -= elfete.ObtenerValorDeAtaque() * this.ObtenerValorDefensa() / 100;

        if (this.vida <= 0)
        {
            Console.WriteLine($"Tu Elfo, {Nombre} fue ejecutado y despedazado vilmente por {elfete.Nombre}.");
        }
    }

    public void RecibirAtaqueEnano(Enano enanete)
    {
        vida -= enanete.ObtenerValorDeAtaque() * this.ObtenerValorDefensa() / 100;

        if (this.vida <= 0)
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
        this.vida += 10;
        Console.WriteLine($" +10 puntos de vida. \n Salud de {Nombre}: {Vida}");
    }

    public void AgregarItem(Elemento item)
    {
        if (!listaItems.Contains(item))
        {
            listaItems.Add(item);
            Console.WriteLine($"{item.Nombre} fue agregado al inventario de {this.Nombre}.");
        }
        
    }

    public void QuitarItem(Elemento item)
    {
        if (listaItems.Contains(item))
        {
            listaItems.Remove(item);
            Console.WriteLine($"{item.Nombre} fue quitado del inventario de {this.Nombre}.");
        }
    }
}