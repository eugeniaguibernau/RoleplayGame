using Program.Personajes;

namespace Program;

public class Batalla
{
    private List<Heroe> Heroes { get; set; }
    private List<Enemigo> Enemigos { get; set; }

    public Batalla(List<Heroe> heroes, List<Enemigo> enemigos)
    {
        Heroes = heroes;
        Enemigos = enemigos;
    }

    public void DoEncounter()
    {
        while (Heroes.Any() && Enemigos.Any())
        {
            FaseAtaqueEnemigos();
            RemoverHeroesDerrotados();

            FaseAtaqueHeroes();
            RemoverEnemigosDerrotados();

            CurarHeroesConVpAlto();
        }

        FinBatalla();
    }

    private void FaseAtaqueEnemigos()
    {
        int numHeroes = Heroes.Count; // Se guarda el número de héroes para evitar recalcularlo en cada iteración ej: 4
        for (int i = 0; i < Enemigos.Count; i++) // Se recorre la lista de enemigos
        {
            int indexHeroe =
                i % numHeroes; // Se calcula el índice del héroe que recibirá el ataque ej: 0, 1, 2, 3, 0, 1, 2, 3
            Heroes[indexHeroe].RecibirAtaque(Enemigos[i]); // Se ataca al héroe correspondiente
        }
    }

    public void RemoverHeroesDerrotados()
    {
        Heroes.RemoveAll(heroe => heroe.Vida == 0);
    }

    private void FaseAtaqueHeroes()
    {
        foreach (var heroe in Heroes)
        {
            foreach (var enemigo in Enemigos.ToList())
            {
                enemigo.RecibirAtaque(heroe);
                if (enemigo.Vida == 0)
                {
                    heroe.ObtenerVP(enemigo);
                }
            }
        }
    }

    public void RemoverEnemigosDerrotados()
    {
        Enemigos.RemoveAll(enemigo => enemigo.Vida == 0);
    }

    private void CurarHeroesConVpAlto()
    {
        foreach (var heroe in Heroes.Where(h => h.VP >= 5))
        {
            heroe.Curar();
        }
    }

    private void FinBatalla()
    {
        Console.WriteLine("La batalla ha terminado");
    }
}