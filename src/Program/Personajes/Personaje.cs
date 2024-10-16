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


    public abstract void RecibirAtaque(IPersonaje personaje);
    

    public void AgregarElemento(IElementos elemento)
    {
        elementos.Add(elemento);
    }

    public void QuitarElemento(IElementos elemento)
    {
        elementos.Remove(elemento);
    }

}