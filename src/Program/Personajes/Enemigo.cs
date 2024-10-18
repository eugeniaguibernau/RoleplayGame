using Program.Interfaces;

namespace Program.Personajes;

public class Enemigo : Personaje
{
    public Enemigo(string nombre, double vida, List<IElementos> elementos, int vp)
    {
        this.Nombre = nombre;
        this.Vida = vida;
        this.elementos = elementos;
        this.VP = vp;
    }

    public override double ObtenerValorDeAtaque()
    {
        double tot = 0;
        foreach (IElementos elemento in elementos)
        {
            if (elemento is IItemAtaque ataqueElemento)
            {
                tot += ataqueElemento.Ataque;
            }
        }

        return tot;
    }

    public override double ObtenerValorDeDefensa()
    {
        double tot = 0;
        foreach (IElementos elemento in elementos)
        {
            if (elemento is IItemDefensa defensaElemento)
            {
                tot += defensaElemento.Defensa;
            }
        }

        return tot;
    }
}