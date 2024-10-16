using Program.Interfaces;

namespace Program.Personajes;

public abstract class Heroe: Personaje
{
    public Heroe()
    {
    }

    public int ObtenerVP()
    {
        return vP;
    }

    public void Curar()
    {
        Vida += 10;
        Console.WriteLine($" +10 puntos de vida. \n Salud de {Nombre}: {Vida}");
    }

    public override double ObtenerValorDeAtaque()
    {
        throw new NotImplementedException();
    }

    public override double ObtenerValorDeDefensa()
    {
        throw new NotImplementedException();
    }

    public override void RecibirAtaque(IPersonaje personaje)
    {
        throw new NotImplementedException();
    }
}