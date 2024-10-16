using Program.Interfaces;

public class Mago : Personaje
{
    private List<IHechizo> hechizos;

    public Mago(string nombre, List<IElementos> elementos, List<IHechizo> hechizos, double vida)
    {
        this.nombre = nombre;
        this.elementos = elementos;
        this.hechizos = hechizos;
        this.vida = vida;
    }

    public List<IHechizo> Hechizos
    {
        get => hechizos;
        set => hechizos = value;
    }

    public override double ObtenerValorDeAtaque()
    {
        double tot = 0;
        foreach (IElementos elemento in elementos)
        {
            if (elemento is IItemAtaque ataqueElemento)
            {
                if (ataqueElemento is IItemMagico itemMagico)
                {
                    // Si es un ItemMagico, se suma el ataque por el multiplicador
                    tot += ataqueElemento.Ataque * (itemMagico.MultiplicadorDanio / 100);
                }
                else
                {
                    // Si no es un ItemMagico, se suma el ataque directamente
                    tot += ataqueElemento.Ataque;
                }
            }
        }

        foreach (IHechizo elemento in hechizos)
        {
            if (elemento is IHechizoAtaque ataqueHechizo)
            {
                tot += ataqueHechizo.Ataque;
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

        foreach (IHechizo elemento in hechizos)
        {
            if (elemento is IHechizoDefensa defensaHechizo)
            {
                tot += defensaHechizo.Defensa;
            }
        }

        return tot;
    }

    public void AgregarHechizo(IHechizo hechizo)
    {
        hechizos.Add(hechizo);
    }

    public void QuitarHechizo(IHechizo hechizo)
    {
        hechizos.Remove(hechizo);
    }
}