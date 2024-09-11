namespace Program;

public class Enanos
{
    public Enanos(string nombre, List<Elementos> elementos, double vida)
    {
        this.nombre = nombre;
        this.elementos = elementos;
        this.vida = vida;
    }

    
    private string nombre;
    
    private List<Elementos> elementos;

    private double vida;

   
    public double Vida
    {
        get => vida;
        set => vida = value; //NO PERMITIR QUE SEA MENOR A 0
    }


    public void Curar()
    {
        //CURARSE A SI MISMO
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
    public void RecibirAtaqueDeElfo(Elfo elfo)
    {
        Vida -= elfo.ObtenerValorDeAtaque;
        vida += (this.ObtenerValorDefensa / 100);
        if (Vida <= 0)
        {
            Console.WriteLine($"{this.nombre} ha muerto");
        }
    }
    
    public void RecibirAtaqueDeMago(Mago mago)
    {
        Vida -= mago.ObtenerValorDeAtaque;
        vida += (this.ObtenerValorDefensa / 100);
    }
}