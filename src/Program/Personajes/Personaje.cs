using Program.Interfaces;

public abstract class Personaje: IPersonaje
{ 
    protected string nombre;
    protected double vida; 
    protected List<IElementos> elementos; //si la hago privada o protected me dice que no está implementada la interfaz
    protected int vP; 
   
   public int VP
   {
       get => vP;
       set => vP = value;
   }
    
    public string Nombre
    {
        get => nombre;
        set => nombre = value ?? throw new ArgumentNullException(nameof(value));
    }

    public double Vida
    {
        get => vida;
        set => vida = value;
    }
    
    public List<IElementos> Elementos
    {
        get => elementos;
        set => elementos = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    public abstract double ObtenerValorDeAtaque();


    public abstract double ObtenerValorDeDefensa();


    public void RecibirAtaque(IPersonaje personaje)
    {
        double dano = Math.Max(personaje.ObtenerValorDeAtaque() - ObtenerValorDeDefensa(), 0);
        Vida -= dano;
        if (Vida <= 0)
        {
            Console.WriteLine($"{Nombre} ha muerto");
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