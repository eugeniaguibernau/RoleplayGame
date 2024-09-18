using Program.Interfaces;

namespace Program.Elementos
{
    public class Elementos : IItemAtaque, IItemDefensa
    {
        public string Nombre { get; set; }
        public double Ataque { get; set; }
        public double Defensa { get; set; }

        public Elementos(string nombre, double ataque, double defensa, int multiplicadorDanio)
        {
            Nombre = nombre;
            Ataque = ataque;
            Defensa = defensa;
        }
    }
}