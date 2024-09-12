public class LibroMagico
{
    private List<Hechizos> listaHechizos;

    public LibroMagico()
    {
        listaHechizos = new List<Hechizos>();
    }

    public void AgregarHechizo(Hechizos hechizo)
    {
        listaHechizos.Add(hechizo);
    }

    public double ObtenerPoderTotal()
    {
        double poderTotal = 0;
        foreach (Hechizos hechizo in listaHechizos)
        {
            poderTotal += hechizo.Ataque; // Sumar el poder de ataque de cada hechizo
        }

        return poderTotal;
    }
}