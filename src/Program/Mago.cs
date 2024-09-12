using System.Runtime.CompilerServices;


public class Mago
{
    private string nombre;
    public string Nombre { get; set; }
    

    private double vida;
    public double Vida { get; set; }

    private List<Elementos> ListaItems;

    private List<Hechizos> LibroMagico;


    public Mago(string nombre, double vida)
    {
        Nombre = nombre;
        Vida = vida;
    }
    

    public double ObtenerValorDefensa()               // Obtener valor de defensa total.
    {
        double defensa = 0;
        foreach (Elementos item in ListaItems)
        {
            defensa += item.Defensa;
        }

        return defensa;
    }
    

    public void RecibirAtaqueEnano(Enanos enano)
    {
        Vida -= enano.ObtenerValorDeAtaque() * this.ObtenerValorDefensa()/100;
        if (Vida <= 0)
        {
            Vida = 0;
            Console.WriteLine($"Tu mago {Nombre} ha recibido {enano.ObtenerValorDeAtaque()} puntos de damage y ha muerto.");
        }
        Console.WriteLine($"Tu mago {Nombre} ha recibido {enano.ObtenerValorDeAtaque()} puntos de damage y le quedan {Vida} puntos de vida. Ojo con Gaspar!");
    }

    
    public void RecibirAtaqueElfo(Elfo elfo)
    {
        Vida -= elfo.ObtenerValorDeAtaque() * this.ObtenerValorDefensa()/100;
        if (Vida <= 0)
        {
            Vida = 0;
            Console.WriteLine($"Tu mago {Nombre} ha recibido {elfo.ObtenerValorDeAtaque()} puntos de damage y ha muerto.");
        }
        Console.WriteLine($"Tu mago {Nombre} ha recibido {elfo.ObtenerValorDeAtaque()} puntos de damage y le quedan {Vida} puntos de vida. Ojo con Gaspar!");
    }
    
    
    public void RecibirAtaqueMago(Mago mago)
    {
        Vida -= this.ObtenerValorDeAtaque() * this.ObtenerValorDefensa()/100;
        if (Vida <= 0)
        {
            Vida = 0;
            Console.WriteLine($"Tu mago {Nombre} ha recibido {this.ObtenerValorDeAtaque()} puntos de damage y ha muerto.");
        }
        Console.WriteLine($"Tu mago {Nombre} ha recibido {this.ObtenerValorDeAtaque()} puntos de damage y le quedan {Vida} puntos de vida. Ojo con Gaspar!");
    }

    
    public void Curar()                                                
    {
        if (Vida < 200)  // Vida maxima, digamos que 200.
        {
            Vida += 15;
            Console.WriteLine($"{Nombre} ha recuperado {15} puntos de salud.");
        }
        else
        {
            Console.WriteLine($"No puedes curarte, pues ya tienes mucha vida.");
        }
    }
    
    
    public void AgregarHechizo(Hechizos hechizo)
    {
        if (!LibroMagico.Contains(hechizo))
        {
            LibroMagico.Add(hechizo);
            Console.WriteLine($"{Nombre} ha aprendido el hechizo {hechizo.Nombre}.");
        }
    }
    
    public void QuitarHechizo(Hechizos hechizo)
    {
        if (LibroMagico.Contains(hechizo))
        {
            ListaItems.Remove(hechizo);
            Console.WriteLine($"{Nombre} ha olvidado el hechizo {hechizo.Nombre}.");
        }
    }

    public double ObtenerPoderTotalHechizos()
    {
        double poderTotal = 0;
        foreach (Hechizos hechizo in LibroMagico)
        {
            poderTotal += hechizo.Ataque;                       // Sumar el poder de ataque de cada hechizo
        }
        return poderTotal;
    }
    

    public double ObtenerValorDeAtaque()
    {
        double poderItems = 0;
        foreach (Elementos item in ListaItems)
        {
            poderItems += item.Ataque;                          // Suma el valor de ataque de cada ítem
        }
        
        double poderHechizos = ObtenerPoderTotalHechizos();    // El poder sumado de todos los hechizos.
        
        return poderItems + poderHechizos;                     // Aca estaria retornando el poder total maximo que lanza el mago.
    }

    
    
    public void AgregarItem(Elementos item)                    // Metodos para agregar y quitar items
    {
        if (!ListaItems.Contains(item))
        {
            ListaItems.Add(item);
            Console.WriteLine($"{item.Nombre} fue agregado al inventario de {Nombre}.");
        }
    }
    
    public void QuitarItem(Elementos item)
    {
        if (ListaItems.Contains(item))
        {
            ListaItems.Remove(item);
            Console.WriteLine($"{item.Nombre} fue quitado del inventario de {Nombre}.");
        }
    }

}    
