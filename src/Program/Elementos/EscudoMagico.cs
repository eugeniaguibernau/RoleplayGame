using Program.Interfaces;

namespace Program.Elementos
{
    public class EscudoMagico : IHechizoDefensa
    {
        public double Defensa { get; set; }
        public string Nombre { get; set; }
        public double MagiaDefensiva { get; set; }

        public EscudoMagico(string nombre, double defensa, double magiaDefensiva)
        {
            this.Nombre = nombre;
            this.Defensa = defensa;
            this.MagiaDefensiva = magiaDefensiva;
        }

        public double ObtenerValorTotalDefensa()
        {
            return this.Defensa + this.MagiaDefensiva;
        }
    }
}