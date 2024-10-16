namespace Program.Interfaces;

public interface IPersonaje
{
    string Nombre { get; set; }
    double Vida { get; set; }
    List<IElementos> Elementos { get; set; }
    int VP { get; set; }
    double ObtenerValorDeAtaque();
    double ObtenerValorDeDefensa();
    void RecibirAtaque(IPersonaje personaje);
    //void Curar(); no va acá, lo llevan solo los héroes
    void AgregarElemento(IElementos elemento);
    void QuitarElemento(IElementos elemento);
}