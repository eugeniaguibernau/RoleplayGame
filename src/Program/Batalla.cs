using Program.Personajes;

public class Batalla
{
    public List<Heroe> Heroes { get; set; }
    public List<Enemigo> Enemigos { get; set; }

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

            if (!Heroes.Any()) break; // Salir si todos los héroes han sido derrotados

            FaseAtaqueHeroes();
            RemoverEnemigosDerrotados();
            CurarHeroesConVpAlto();
        }

        FinBatalla();
    }

    private void FaseAtaqueEnemigos()
    {
        int numHeroes = Heroes.Count;
        for (int i = 0; i < Enemigos.Count; i++)
        {
            int indexHeroe = i % numHeroes; // El héroe que recibirá el ataque
            Heroes[indexHeroe].RecibirAtaque(Enemigos[i]); // El héroe recibe el ataque del enemigo
        }
    }

    public void RemoverHeroesDerrotados()
    {
        Heroes.RemoveAll(heroe => heroe.Vida <= 0); // Remover héroes cuya vida sea cero o menor
    }

    public void FaseAtaqueHeroes()
    {
        foreach (var heroe in Heroes.ToList())
        {
            foreach (var enemigo in Enemigos.ToList())
            {
                enemigo.RecibirAtaque(heroe);
                if (enemigo.Vida <= 0)
                {
                    heroe.ObtenerVP(enemigo);
                    RemoverEnemigosDerrotados();
                }
            }
        }
    }

    public void RemoverEnemigosDerrotados()
    {
        Enemigos.RemoveAll(enemigo => enemigo.Vida <= 0); // Remover enemigos cuya vida sea cero o menor
    }

    public void CurarHeroesConVpAlto()
    {
        foreach (var heroe in Heroes.Where(h => h.VP >= 5)) // No es necesario verificar si está vivo aquí
        {
            heroe.Curar();
        }
    }

    private void FinBatalla()
    {
        string ganador = Heroes.Any() ? "los héroes" : "los enemigos";
        Console.WriteLine($"La batalla ha terminado. Ganaron {ganador}.");
    }
}