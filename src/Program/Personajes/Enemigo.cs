using Program.Interfaces;

namespace Program.Personajes;

public class Enemigo : Personaje
{
    public Enemigo()
    {
    }

    public override double ObtenerValorDeAtaque()
    {
        double tot = 0;

        if (elementos != null)
        {
            foreach (IElementos elemento in elementos)
            {
                if (elemento is IItemAtaque ataqueElemento)
                {
                    tot += ataqueElemento.Ataque;
                }
            }
        }

        return tot;
    }

    public override double ObtenerValorDeDefensa()
    {
        double tot = 0;

        // Check if 'elementos' is null before iterating
        if (elementos != null)
        {
            foreach (IElementos elemento in elementos)
            {
                if (elemento is IItemDefensa defensaElemento)
                {
                    tot += defensaElemento.Defensa;
                }
            }
        }

        return tot;
    }
}