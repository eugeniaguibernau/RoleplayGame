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

            CurarHeroesConVPAlto();
        }

        FinBatalla();
    }

    private void FaseAtaqueEnemigos()
    {
        int numHeroes = Heroes.Count;
        for (int i = 0; i < Enemigos.Count; i++)
        {
            int indexHeroe = i % numHeroes;
            Heroes[indexHeroe].RecibirAtaque(Enemigos[i]);
        }
    }

    public void RemoverHeroesDerrotados()
    {
        Heroes.RemoveAll(heroe => heroe.Vida == 0);
    }

    private void FaseAtaqueHeroes()
    {
        foreach (var heroe in Heroes.Where(h => h.Vida > 0))
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

    private void CurarHeroesConVPAlto()
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