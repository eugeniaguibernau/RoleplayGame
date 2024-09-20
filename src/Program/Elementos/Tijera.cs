using Program.Interfaces;

namespace Program.Elementos
{
    public class Tijera : IItemAtaque, IItemDefensa
    {
        public double Ataque { get; set; }
        public double Defensa { get; set; }
        public string Nombre { get; set; }

        public Tijera(string nombre, double ataque, double defensa)
        {
            this.Nombre = nombre;
            this.Ataque = ataque;
            this.Defensa = defensa;
        }
    }
}