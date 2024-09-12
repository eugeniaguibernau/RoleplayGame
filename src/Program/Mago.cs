public class Mago
{
    private string nombre;
    public string Nombre { get; set; }


    private double vida;
    public double Vida { get; set; }

    private List<Elementos> elementos;


    private LibroMagico libroDeHechizos;
    public LibroMagico LibroDeHechizos => libroDeHechizos;


    public Mago(string nombre, List<Elementos> elementos, double vida)
    {
        Nombre = nombre;
        this.elementos = elementos;
        Vida = vida;
    }

    public string ObtenerNombre() // Metodo para devolver el nombre del Magucho.
    {
        return Nombre;
    }

    public double ObtenerVida() // Metodo para devolver el valor de vida del Magucho.
    {
        return Vida;
    }

    public double ObtenerValorDefensa()
    {
        double defensa = 0;
        foreach (Elementos item in elementos)
        {
            defensa += item.Defensa;
        }

        return defensa;
    }


    public void RecibirAtaqueEnano(Enanos enano)
    {
        Vida -= enano.ObtenerValorDeAtaque() * this.ObtenerValorDefensa() / 100;
        if (Vida <= 0)
        {
            Vida = 0;
            Console.WriteLine(
                $"Tu mago {Nombre} ha recibido {enano.ObtenerValorDeAtaque()} puntos de damage y ha muerto.");
        }

        Console.WriteLine(
            $"Tu mago {Nombre} ha recibido {enano.ObtenerValorDeAtaque()} puntos de damage y le quedan {Vida} puntos de vida. Ojo con Gaspar!");
    }


    public void RecibirAtaqueElfo(Elfo elfo)
    {
        Vida -= elfo.ObtenerValorDeAtaque() * this.ObtenerValorDefensa() / 100;
        if (Vida <= 0)
        {
            Vida = 0;
            Console.WriteLine(
                $"Tu mago {Nombre} ha recibido {elfo.ObtenerValorDeAtaque()} puntos de damage y ha muerto.");
        }

        Console.WriteLine(
            $"Tu mago {Nombre} ha recibido {elfo.ObtenerValorDeAtaque()} puntos de damage y le quedan {Vida} puntos de vida. Ojo con Gaspar!");
    }


    public void RecibirAtaqueMago(Mago mago)
    {
        Vida -= this.ObtenerValorDeAtaque() * this.ObtenerValorDefensa() / 100;
        if (Vida <= 0)
        {
            Vida = 0;
            Console.WriteLine(
                $"Tu mago {Nombre} ha recibido {this.ObtenerValorDeAtaque()} puntos de damage y ha muerto.");
        }

        Console.WriteLine(
            $"Tu mago {Nombre} ha recibido {this.ObtenerValorDeAtaque()} puntos de damage y le quedan {Vida} puntos de vida. Ojo con Gaspar!");
    }


    public void Curar()
    {
        if (Vida <= Vida - 15)
        {
            Vida += 15;
            Console.WriteLine($"{Nombre} ha recuperado {15} puntos de salud. Enhorabuena!, pero ojito con Gaspar!");
        }

        Console.WriteLine($"No puedes curarte, pues ya tienas mucha vida.");
    }


    public double ObtenerValorDeAtaque()
    {
        double poderItems = 0;
        foreach (Elementos item in elementos)
        {
            poderItems += item.Ataque; // Suma el valor de ataque de cada ítem
        }

        double poderHechizos = LibroDeHechizos.ObtenerPoderTotal(); // El poder sumado de todos los hechizos.

        return poderItems + poderHechizos; // Aca estaria retornando el poder total maximo que lanza el mago.
    }

    public void AgregarElemento(Elementos elemento)
    {
        elementos.Add(elemento);
    }

    public void QuitarElemento(Elementos elemento)
    {
        elementos.Remove(elemento);
    }
}