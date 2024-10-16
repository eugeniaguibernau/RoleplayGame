using Program.Interfaces;

namespace Program.Personajes;

public class Enemigo : Personaje
{
    public Enemigo()
    {
        
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