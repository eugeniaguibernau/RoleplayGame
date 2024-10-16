namespace Program.Personajes;

public abstract class Heroe : Personaje
{
    public Heroe()
    {
    }

    public void ObtenerVP(Enemigo enemigo)
    {
        this.vP += enemigo.VP;
        enemigo.VP = 0;
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
}