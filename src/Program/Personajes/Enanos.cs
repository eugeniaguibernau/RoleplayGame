using Program.Elementos;
using Program.Interfaces;

public class Enanos : Personaje
{

    public Enanos(string nombre, List<IElementos> elementos, double vida)
    {
        this.Nombre = nombre;
        this.elementos = elementos;
        //this.Espada = espada;
        //this.Escudo = escudo;
        this.Vida = vida;
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