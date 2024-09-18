using Program.Interfaces;

namespace Program.Elementos
{
    public class Hechizos : IItemAtaque, IItemDefensa, IItemMagico
    {
        public string Nombre { get; set; }
        public double Ataque { get; set; }
        public double Defensa { get; set; }
        public int MultiplicadorDanio { get; set; }

        public Hechizos(string nombre, double ataque, double defensa, int multiplicadorDanio)
        {
            Nombre = nombre;
            Ataque = ataque;
            Defensa = defensa;
            MultiplicadorDanio = multiplicadorDanio;
        }
    }
}