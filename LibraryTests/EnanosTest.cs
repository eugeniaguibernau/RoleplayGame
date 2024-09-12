namespace LibraryTests;

public class EnanosTest
{
    [Test]
    public void TestObtenerValorAtaque()
    {
        Elementos Elemento1Enano1 = new Elementos("Espada1", 15, 2, "Espada?");
        Elementos Elemento2Enano1 = new Elementos("Cuchillo", 5, 1, "yqs");
        Enanos EnanoUno = new Enanos("Enanito1", new List<Elementos>(), 100);
        EnanoUno.AgregarElemento(Elemento1Enano1);
        EnanoUno.AgregarElemento(Elemento2Enano1);
        Assert.AreEqual(20, EnanoUno.ObtenerValorDeAtaque());
    }

    [Test]
    public void TestObtenerValorDefensa()
    {
        Elementos Elemento1Enano2 = new Elementos("Espada1", 15, 2, "Espada?");
        Elementos Elemento2Enano2 = new Elementos("Escudo", 2, 8, "yqs");
        Enanos EnanoDos = new Enanos("Enanito2", new List<Elementos>(), 100);
        EnanoDos.AgregarElemento(Elemento1Enano2);
        EnanoDos.AgregarElemento(Elemento2Enano2);
        Assert.AreEqual(10, EnanoDos.ObtenerValorDeDefensa()); // Cambiado a Defensa
    }

    [Test]
    public void TestEnanoAtacaEnano()
    {
        // Enano 1
        Elementos Elemento1Enano1 = new Elementos("Espada1", 15, 2, "Espada?");
        Elementos Elemento2Enano1 = new Elementos("Cuchillo", 5, 1, "yqs");
        Enanos EnanoUno = new Enanos("Enanito1", new List<Elementos> { Elemento1Enano1 }, 100);
        EnanoUno.AgregarElemento(Elemento2Enano1);

        // Enano 2
        Elementos Elemento1Enano2 = new Elementos("Espada1", 15, 2, "Espada?");
        Elementos Elemento2Enano2 = new Elementos("Escudo", 2, 8, "yqs");
        Enanos EnanoDos = new Enanos("Enanito2", new List<Elementos> { Elemento1Enano2 }, 100);
        EnanoDos.AgregarElemento(Elemento2Enano2);

        // Enano 2 ataca al enano 1
        EnanoUno.RecibirAtaqueDeEnano(EnanoDos);

        // Verifico que la vida del enano atacado (1) sea la esperada
        Assert.AreEqual(90, EnanoUno.Vida); // Aquí asumo un valor de vida que debes ajustar según las reglas de ataque/defensa
    }

    [Test]
    public void TestElfoAtacaEnano()
    {
        // Enano 1
        Elementos Elemento1Enano1 = new Elementos("Espada1", 15, 2, "Espada?");
        Elementos Elemento2Enano1 = new Elementos("Cuchillo", 5, 1, "yqs");
        Enanos EnanoUno = new Enanos("Enanito1", new List<Elementos> { Elemento1Enano1 }, 100);
        EnanoUno.AgregarElemento(Elemento2Enano1);

        // Elfo
        Elementos Elemento1Elfo = new Elementos("Espada1", 15, 2, "Espada?");
        Elementos Elemento2Elfo = new Elementos("Escudo", 2, 8, "yqs");
        Elfo ElfoAtacante = new Elfo("Elfo1", new List<Elementos> { Elemento1Elfo }, 100);
        ElfoAtacante.AgregarElemento(Elemento2Elfo);

        // Elfo ataca al enano
        EnanoUno.RecibirAtaqueDeElfo(ElfoAtacante); // Asegúrate de tener este método o uno genérico que maneje diferentes tipos

        // Verifico que la vida del enano atacado (1) sea la esperada
        Assert.AreEqual(98.3, EnanoUno.Vida); // Ajusta según las reglas
    }

    [Test]
    public void TestMagoAtacaEnano()
    {
        // Enano 1
        Elementos Elemento1Enano1 = new Elementos("Espada1", 15, 2, "Espada?");
        Elementos Elemento2Enano1 = new Elementos("Cuchillo", 5, 1, "yqs");
        Enanos EnanoUno = new Enanos("Enanito1", new List<Elementos> { Elemento1Enano1 }, 100);
        EnanoUno.AgregarElemento(Elemento2Enano1);

        // Mago
        Elementos Elemento1Mago = new Elementos("Báculo", 20, 1, "Mágico");
        Elementos Elemento2Mago = new Elementos("Escudo", 2, 8, "yqs");
        Mago MagoAtacante = new Mago("Mago1", new List<Elementos> { Elemento1Mago }, new List<Hechizos>(), 100);
        MagoAtacante.AgregarElemento(Elemento2Mago);

        // Mago ataca al enano
        EnanoUno.RecibirAtaqueDeMago(MagoAtacante);

        // Verifico que la vida del enano atacado (1) sea la esperada
        Assert.AreEqual(85, EnanoUno.Vida); // Ajusta según las reglas
    }

    [Test]
    public void TestEnanoSeCura()
    {
        Enanos EnanoDebil = new Enanos("Enanito", new List<Elementos>(), 10);
        EnanoDebil.Curar();
        Assert.AreEqual(20, EnanoDebil.Vida);
    }
}