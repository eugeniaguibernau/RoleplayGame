namespace Program.Interfaces;

public interface IPersonaje
{
    string Nombre { get; set; }
    double Vida { get; set; }
    List<Elementos> Elementos { get; set; }
    double ObtenerValorDeAtaque();
    double ObtenerValorDeDefensa();
    void RecibirAtaque(IPersonaje personaje);
    void Curar();
}