namespace LibraryTests;

public class ElfoTests
{
    [Test]
    public void TestObtenerValorAtaque()
    {
        // Crear elementos
        var elemento1 = new Elementos("Espada de chocolate", 15, 2, "Espada");
        var elemento2 = new Elementos("Rifle de caza con gatillo derretido", 10, 3, "Arma larga");

        // Crear elfo y agregar elementos
        var elfo = new Elfo("Elfo pedante", new List<Elementos> { elemento1 }, 100);
        elfo.AgregarElemento(elemento2);

        // Verificar que el ataque total es la suma correcta
        Assert.That(elfo.ObtenerValorDeAtaque(), Is.EqualTo(25));
    }

    [Test]
    public void TestObtenerValorDefensa()
    {
        // Crear elementos
        var elemento1 = new Elementos("Escudo", 0, 10, "Defensa");
        var elemento2 = new Elementos("Armadura", 0, 5, "Protección");

        // Crear elfo y agregar elementos
        var elfo = new Elfo("Elfo2", new List<Elementos> { elemento1 }, 100);
        elfo.AgregarElemento(elemento2);

        // Verificar que la defensa total es la suma correcta
        Assert.That(elfo.ObtenerValorDefensa(), Is.EqualTo(15));
    }

    [Test]
    public void TestElfoAtacaElfo()
    {
        // Crear elfo atacante
        var elementoAtaque = new Elementos("Espada", 20, 5, "Arma");
        var elfoAtacante = new Elfo("Elfo Atacante enojado", new List<Elementos> { elementoAtaque }, 100);

        // Crear elfo defensor
        var elementoDefensa = new Elementos("Escudo", 5, 10, "Defensa");
        var elfoDefensor = new Elfo("ElfoDefensor", new List<Elementos> { elementoDefensa }, 90);

        // Elfo atacante ataca al elfo defensor
        elfoDefensor.RecibirAtaqueElfo(elfoAtacante);

        // Verificar la vida restante
        double expectedDano = CalcularDano(elfoAtacante, elfoDefensor);
        double expectedVida = 90 - expectedDano;
        Assert.That(elfoDefensor.Vida, Is.EqualTo(expectedVida));
    }

    [Test]
    public void TestMagoAtacaElfo()
    {
        // Crear elfo
        var elementoElfo = new Elementos("Armadura", 0, 5, "Protección");
        var elfo = new Elfo("Elfo1", new List<Elementos> { elementoElfo }, 100);

        // Crear mago
        var elementoMago = new Elementos("Palo de madera con brillo", 30, 0, "Magia");
        var mago = new Mago("Mago1", new List<Elementos> { elementoMago }, new List<Hechizos>(), 100);

        // Mago ataca al elfo
        elfo.RecibirAtaqueMago(mago);

        // Verificar vida restante del elfo
        double expectedDano = CalcularDano(mago, elfo);
        double expectedVida = 100 - expectedDano;
        Assert.That(elfo.Vida, Is.EqualTo(expectedVida));
    }

    [Test]
    public void TestElfoSeCura()
    {
        // Crear elfo con poca vida
        var elfoDebil = new Elfo("ElfoDebilucho", new List<Elementos>(), 20);

        // Elfo se cura
        elfoDebil.Curar();

        // Verificar que la vida aumentó correctamente (+10)
        Assert.That(elfoDebil.Vida, Is.EqualTo(30));
    }

    private double CalcularDano(Enanos enanoAtacante, Elfo elfoAtacado)
    {
        return Math.Max(enanoAtacante.ObtenerValorDeAtaque() - elfoAtacado.ObtenerValorDefensa(), 0);
    }

    private double CalcularDano(Elfo elfoAtacante, Elfo elfoAtacado)
    {
        return Math.Max(elfoAtacante.ObtenerValorDeAtaque() - elfoAtacado.ObtenerValorDefensa(), 0);
    }

    private double CalcularDano(Mago magoAtacante, Elfo elfoAtacado)
    {
        return Math.Max(magoAtacante.ObtenerValorDeAtaque() - elfoAtacado.ObtenerValorDefensa(), 0);
    }
}