public class Enanos
{
    private string nombre;
    private List<Elementos> elementos;
    private double vida; 
    
    public Enanos(string nombre, List<Elementos> elementos, double vida)
    {
        this.nombre = nombre;
        this.elementos = elementos;
        this.vida = vida;
    } 
    
    public double Vida
    {
        get => vida;
        set => vida = value;
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
        elementos.Add(elemento);
    }

    public void QuitarElemento(Elementos elemento)
    {
        elementos.Remove(elemento);
    }

    public void Curar()
    {
        if (Vida + 50 <= 100)
        {
            vida += 50;
        }
        else
        {
            vida = 100;
        }
    }
    
    public void RecibirAtaqueDeEnano(Enanos enano)
    {
        Vida -= enano.ObtenerValorDeAtaque();
        Vida += (this.ObtenerValorDeDefensa()/ 100);
        if (Vida <= 0)
        {
            Console.WriteLine($"{nombre} ha muerto");
        }
    }
    public void RecibirAtaqueDeElfo(Elfo elfo)
    {
        Vida -= elfo.ObtenerValorDeAtaque;
        Vida += (this.ObtenerValorDeDefensa() / 100);
        if (Vida <= 0)
        {
            Console.WriteLine($"{nombre} ha muerto");
        }
    }
    
    public void RecibirAtaqueDeMago(Mago mago)
    {
        Vida -= mago.ObtenerValorDeAtaque;
        Vida += (this.ObtenerValorDeDefensa()/ 100);
        if (Vida <= 0)
        {
            Console.WriteLine($"{nombre} ha muerto");
        }
    }
}