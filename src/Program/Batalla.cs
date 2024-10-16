using Program.Personajes;

namespace Program;

public class Batalla
{
    public List<Heroe> Heroes { get; set; }
    public List<Enemigo> Enemigos { get; set; }

    public Batalla(List<Heroe> heroes, List<Enemigo> enemigos)
    {
        this.Heroes = heroes;
        this.Enemigos = enemigos;
    }

    public void DoEncounter()
    {
        int numHeroes = Heroes.Count; // Obtiene el número de héroes 3
        int numEnemigos = Enemigos.Count; // Obtiene el número de enemigos 4

        // Caso 1: Si solo hay un héroe
        if (numHeroes == 1)
        {
            // Todos los enemigos atacan al único héroe (el héroe en la posición 0)
            Enemigos.ForEach(enemigo => { Heroes[0].RecibirAtaque(enemigo); });
        }
        // Caso 2: Si hay más de un héroe
        else if (numHeroes > 1)
        {
            // Se distribuyen los ataques entre los héroes
            for (int i = 0; i < numEnemigos; i++) // Itera sobre cada enemigo
            {
                // Calcula el índice del héroe que recibirá el ataque
                // Usando la operación i % numHeroes, los ataques se reparten cíclicamente
                // Si hay más enemigos que héroes, este operador asegura que los héroes
                // sean atacados de manera equitativa y en secuencia
                int indexHeroe = i % numHeroes; // 0, 1, 2, 0

                // El héroe correspondiente recibe el ataque del enemigo actual
                Heroes[indexHeroe].RecibirAtaque(Enemigos[i]);
            }
        }
    }
}