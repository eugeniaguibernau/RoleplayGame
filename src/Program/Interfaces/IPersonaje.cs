namespace Program.Interfaces;

public interface IPersonaje
{
    string Nombre { get; set; }
    double Vida { get; set; }
    double ObtenerValorDeAtaque();
    double ObtenerValorDeDefensa();
    void RecibirAtaque(IPersonaje personaje);
    void Curar();
    void AgregarElemento(IElementos elemento);
    void QuitarElemento(IElementos elemento);
}