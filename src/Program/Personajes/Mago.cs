using Program.Interfaces;

public class Mago : IPersonaje
{
    private string nombre;
    private double vida;
    private List<IElemento> elementos;

    public Mago(string nombre, List<IElemento> elementos, double vida)
    {
        this.nombre = nombre;
        this.elementos = elementos ?? new List<IElemento>();
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

    public List<IElemento> Elementos
    {
        get => elementos;
        set => elementos = value;
    }

    public double ObtenerValorDeDefensa()
    {
        double defensa = 0;
        foreach (IElemento item in elementos)
        {
            defensa += item.Defensa;
        }

        return defensa;
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

    public double ObtenerValorDeAtaque()
    {
        double poderTotal = 0;
        foreach (IElemento item in elementos)
        {
            poderTotal += item.Ataque;
        }

        return poderTotal;
    }

    public void AgregarElemento(IElemento elemento)
    {
        elementos.Add(elemento);
    }

    public void QuitarElemento(IElemento elemento)
    {
        elementos.Remove(elemento);
    }
}