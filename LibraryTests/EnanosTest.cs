namespace LibraryTests;

public class EnanosTest
{
    [Test]
    public void TestObtenerValorAtaque()
    {
        // Creo elementos para agregar después
        Elementos elemento1Enano1 = new Elementos("Espada1", 15, 2, "Espada?");
        Elementos elemento2Enano1 = new Elementos("Cuchillo", 5, 1, "yqs");
        //Creo un enano
        Enanos enanoUno = new Enanos("Enanito1", new List<Elementos>(), 100);
        //Le agrego los elementos
        enanoUno.AgregarElemento(elemento1Enano1);
        enanoUno.AgregarElemento(elemento2Enano1);
        //Verifico que el método obtener valor de ataque sume el ataque de todos los elementos agregados correctamente
        Assert.That(enanoUno.ObtenerValorDeAtaque(), Is.EqualTo(20));
    }

    [Test]
    public void TestObtenerValorDefensa()
    {
        // Creo elementos para agregar después
        Elementos elemento1Enano2 = new Elementos("Espada1", 15, 2, "Espada?");
        Elementos elemento2Enano2 = new Elementos("Escudo", 2, 8, "yqs");
        //Le agrego los elementos
        Enanos enanoDos = new Enanos("Enanito2", new List<Elementos>(), 100);
        enanoDos.AgregarElemento(elemento1Enano2);
        enanoDos.AgregarElemento(elemento2Enano2);
        //Verifico que se sumen las defensas de los elementos correctamente
        Assert.That(enanoDos.ObtenerValorDeDefensa(), Is.EqualTo(10)); // Cambiado a Defensa
    }

    [Test]
    public void TestEnanoAtacaEnano()
    {
        // Creo un Enano 1
        Elementos elemento1Enano1 = new Elementos("Espada1", 15, 2, "Espada?");
        Elementos elemento2Enano1 = new Elementos("Cuchillo", 5, 1, "yqs");
        Enanos enanoUno = new Enanos("Enanito1", new List<Elementos> { elemento1Enano1 }, 100);
        enanoUno.AgregarElemento(elemento2Enano1);
        // Creo un Enano 2
        Elementos elemento1Enano2 = new Elementos("Espada1", 15, 2, "Espada?");
        Elementos elemento2Enano2 = new Elementos("Escudo", 2, 8, "yqs");
        Enanos enanoDos = new Enanos("Enanito2", new List<Elementos> { elemento1Enano2 }, 100);
        enanoDos.AgregarElemento(elemento2Enano2);
        // Enano 2 ataca al enano 1
        enanoUno.RecibirAtaqueDeEnano(enanoDos);
        double expectedDano = Math.Max(enanoDos.ObtenerValorDeAtaque() - enanoUno.ObtenerValorDeDefensa(), 0);
        double expectedVida = 100 - expectedDano;
        // Verifico que la vida del enano atacado (1) sea la esperada
        Assert.That(enanoUno.Vida, Is.EqualTo(expectedVida));
    }

    [Test]
    public void TestElfoAtacaEnano()
    {
        // Enano 1
        Elementos elemento1Enano1 = new Elementos("Espada1", 15, 2, "Espada?");
        Elementos elemento2Enano1 = new Elementos("Cuchillo", 5, 1, "yqs");
        Enanos enanoUno = new Enanos("Enanito1", new List<Elementos> { elemento1Enano1 }, 100);
        enanoUno.AgregarElemento(elemento2Enano1);
        // Elfo
        Elementos elemento1Elfo = new Elementos("Espada1", 15, 2, "Espada?");
        Elementos elemento2Elfo = new Elementos("Escudo", 2, 8, "yqs");
        Elfo elfoAtacante = new Elfo("Elfo1", new List<Elementos> { elemento1Elfo }, 100);
        elfoAtacante.AgregarElemento(elemento2Elfo);
        // Elfo ataca al enano
        enanoUno.RecibirAtaqueDeElfo(elfoAtacante); // Asegúrate de tener este método o uno genérico que maneje diferentes tipos
        double expectedDano = Math.Max(elfoAtacante.ObtenerValorDeAtaque() - enanoUno.ObtenerValorDeDefensa(), 0);
        double expectedVida = 100 - expectedDano;
        // Verifico que la vida del enano atacado (1) sea la esperada
        Assert.That(enanoUno.Vida, Is.EqualTo(expectedVida)); 
    }

    [Test]
    public void TestMagoAtacaEnano()
    {
        // Enano 1
        Elementos elemento1Enano1 = new Elementos("Espada1", 15, 2, "Espada?");
        Elementos elemento2Enano1 = new Elementos("Cuchillo", 5, 1, "yqs");
        Enanos enanoUno = new Enanos("Enanito1", new List<Elementos> { elemento1Enano1 }, 100);
        enanoUno.AgregarElemento(elemento2Enano1);
        // Mago
        Elementos elemento1Mago = new Elementos("Báculo", 20, 1, "Mágico");
        Elementos elemento2Mago = new Elementos("Escudo", 2, 8, "yqs");
        Mago magoAtacante = new Mago("Mago1", new List<Elementos> { elemento1Mago }, new List<Hechizos>(), 100);
        magoAtacante.AgregarElemento(elemento2Mago);
        // Mago ataca al enano
        enanoUno.RecibirAtaqueDeMago(magoAtacante);
        double expectedDano = Math.Max(magoAtacante.ObtenerValorDeAtaque() - enanoUno.ObtenerValorDeDefensa(), 0);
        double expectedVida = 100 - expectedDano;
        // Verifico que la vida del enano atacado (1) sea la esperada
        Assert.That(enanoUno.Vida, Is.EqualTo(expectedVida)); // Ajusta según las reglas
    }

    [Test]
    public void TestEnanoSeCura()
    {
        //Creo un enano con poca vida
        Enanos enanoDebil = new Enanos("Enanito", new List<Elementos>(), 10);
        //Hago que el enano se cure a si mismo y luego verifico que se agregó los puntos de vida correctamente (+10)
        enanoDebil.Curar();
        Assert.That(enanoDebil.Vida, Is.EqualTo(20));
    }
}