using Program.Elementos;
using Program.Interfaces;

namespace LibraryTests;

public class EnanosTest
{
    [Test]
    public void TestObtenerValorAtaque()
    {
        // Crear items de ataque
        var espada = new Espada("Espada1", 15, 2);
        var cuchillo = new Espada("Cuchillo", 5, 1); // Cambiado a Espada

        // Crear enano y agregar elementos de ataque
        var enano = new Enanos("Enano Guerrero", new List<IElementos> { espada }, 100);
        enano.AgregarElemento(cuchillo);

        // Verificar que el ataque total es la suma correcta
        Assert.That(enano.ObtenerValorDeAtaque(), Is.EqualTo(20));
    }

    [Test]
    public void TestObtenerValorDefensa()
    {
        // Crear items de defensa
        var escudo = new Escudo("Escudo de madera", 8);
        var espada = new Espada("Espada defensiva", 10, 2);

        // Crear enano y agregar elementos de defensa
        var enano = new Enanos("Enano Defensor", new List<IElementos> { escudo }, 100);
        enano.AgregarElemento(espada);

        // Verificar que la defensa total es la suma correcta
        Assert.That(enano.ObtenerValorDeDefensa(), Is.EqualTo(10));
    }

    [Test]
    public void TestEnanoAtacaEnano()
    {
        // Crear enano atacante
        var espada = new Espada("Espada de hierro", 20, 3);
        var enanoAtacante = new Enanos("Enano Atacante", new List<IElementos> { espada }, 100);

        // Crear enano defensor
        var escudo = new Escudo("Escudo de hierro", 10);
        var enanoDefensor = new Enanos("Enano Defensor", new List<IElementos> { escudo }, 100);

        // Enano atacante ataca al enano defensor
        enanoDefensor.RecibirAtaque(enanoAtacante);

        // Verificar la vida restante
        double expectedDano = Math.Max(enanoAtacante.ObtenerValorDeAtaque() - enanoDefensor.ObtenerValorDeDefensa(), 0);
        double expectedVida = 100 - expectedDano;
        Assert.That(enanoDefensor.Vida, Is.EqualTo(expectedVida));
    }

    [Test]
    public void TestElfoAtacaEnano()
    {
        // Crear enano defensor
        var escudo = new Escudo("Escudo de hierro", 10);
        var enanoDefensor = new Enanos("Enano Defensor", new List<IElementos> { escudo }, 100);

        // Crear elfo atacante
        var espadaElfo = new Espada("Espada elfica", 15, 2);
        var elfoAtacante = new Elfo("Elfo Atacante", new List<IElementos> { espadaElfo }, 100);

        // Elfo ataca al enano
        enanoDefensor.RecibirAtaque(elfoAtacante);

        // Verificar la vida restante
        double expectedDano = Math.Max(elfoAtacante.ObtenerValorDeAtaque() - enanoDefensor.ObtenerValorDeDefensa(), 0);
        double expectedVida = 100 - expectedDano;
        Assert.That(enanoDefensor.Vida, Is.EqualTo(expectedVida));
    }

    [Test]
    public void TestMagoAtacaEnano()
    {
        // Crear enano defensor
        var escudo = new Escudo("Escudo de hierro", 10);
        var enanoDefensor = new Enanos("Enano Defensor", new List<IElementos> { escudo }, 100);

        // Crear mago atacante
        var bastonMagico = new BastonMagico("Bastón Mágico", 25, 5, 3);
        var magoAtacante = new Mago("Mago Atacante", new List<IElementos> { bastonMagico }, new List<IHechizo>(), 100);

        // Mago ataca al enano
        enanoDefensor.RecibirAtaque(magoAtacante);

        // Verificar la vida restante
        double expectedDano = Math.Max(magoAtacante.ObtenerValorDeAtaque() - enanoDefensor.ObtenerValorDeDefensa(), 0);
        double expectedVida = 100 - expectedDano;
        Assert.That(enanoDefensor.Vida, Is.EqualTo(expectedVida));
    }

    [Test]
    public void TestEnanoSeCura()
    {
        // Crear enano con poca vida
        var enanoDebil = new Enanos("Enano Debil", new List<IElementos>(), 10);

        // Enano se cura
        enanoDebil.Curar();

        // Verificar que la vida aumentó correctamente (+10)
        Assert.That(enanoDebil.Vida, Is.EqualTo(20));
    }
}