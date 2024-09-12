namespace LibraryTests;

public class EnanosTest
{
    [Test]
    public void TestObtenerValorAtaque()
    {
        Elementos Elemento1Enano1 = new Elementos("Espada1", 15, 2, "Espada?");
        Elementos Elemento2Enano1 = new Elementos("Cuchillo", 5, 1, "yqs");
        Enanos EnanoUno = new Enanos("Enanito1", ElementosEnano1 , 100);
        EnanoUno.AgregarElemento(Elemento1Enano1);
        EnanoUno.AgregarElemento(Elemento2Enano1);
        Assert.AreEqual(20, EnanoUno.ObtenerValorDeAtaque());
    }
    
    [Test]
    public void TestObtenerValorDefensa()
    {
        Elementos Elemento1Enano2 = new Elementos("Espada1", 15, 2, "Espada?");
        Elementos Elemento2Enano2 = new Elementos("Escudo", 2, 8, "yqs");
        Enanos EnanoDos = new Enanos("Enanito2", ElementosEnano1 , 100);
        EnanoDos.AgregarElemento(Elemento1Enano2);
        EnanoDos.AgregarElemento(Elemento2Enano2);
        Assert.AreEqual(20, EnanoDos.ObtenerValorDeAtaque());
    }

    [Test]
    public void TestEnanoAtacaEnano()
    {
        //Enano 1
        Elementos Elemento1Enano1 = new Elementos("Espada1", 15, 2, "Espada?");
        Elementos Elemento2Enano1 = new Elementos("Cuchillo", 5, 1, "yqs");
        Enanos EnanoUno = new Enanos("Enanito1", [Elemento1Enano1] , 100);
        EnanoUno.AgregarElemento(Elemento2Enano1);
        
        //Enano2
        Elementos Elemento1Enano2 = new Elementos("Espada1", 15, 2, "Espada?");
        Elementos Elemento2Enano2 = new Elementos("Escudo", 2, 8, "yqs");
        Enanos EnanoDos = new Enanos("Enanito2", [Elemento1Enano2] , 100);
        EnanoDos.AgregarElemento(Elemento2Enano2);
        
        //Enano dos ataca al enano 1
        EnanoUno.RecibirAtaqueDeEnano(EnanoDos);
        //Verifico que la vida del enano atacado(1) sea la esperada
        Assert.AreEqual("Poner vida esperada", EnanoUno.Vida); //FALTA CALCULAR QUE DEBERÍA QUEDAR EN VIDA
    }
    
    [Test]
    public void TestElfoAtacaEnano()
    {
        //Enano 1
        Elementos Elemento1Enano1 = new Elementos("Espada1", 15, 2, "Espada?");
        Elementos Elemento2Enano1 = new Elementos("Cuchillo", 5, 1, "yqs");
        Enanos EnanoUno = new Enanos("Enanito1",[Elemento1Enano1], 100);
        EnanoUno.AgregarElemento(Elemento2Enano1);
        
        //Elfo
        Elementos Elemento1Elfo = new Elementos("Espada1", 15, 2, "Espada?");
        Elementos Elemento2Elfo = new Elementos("Escudo", 2, 8, "yqs");
        Elfo ElfoAtacante = new Elfo("Enanito2", [Elemento1Elfo] , 100);
        ElfoAtacante.AgregarElemento(Elemento2Elfo);
        
        //Elfo ataca al enano
        EnanoUno.RecibirAtaqueDeEnano(ElfoAtacante);
        
        //Verifico que la vida del enano atacado(1) sea la esperada
        Assert.AreEqual("Poner vida esperada", EnanoUno.Vida); //FALTA CALCULAR QUE DEBERÍA QUEDAR EN VIDA
    }
    
    
    [Test]
    public void TestMagoAtacaEnano()
    {
        //Enano 1
        Elementos Elemento1Enano1 = new Elementos("Espada1", 15, 2, "Espada?");
        Elementos Elemento2Enano1 = new Elementos("Cuchillo", 5, 1, "yqs");
        Enanos EnanoUno = new Enanos("Enanito1",[Elemento1Enano1], 100);
        EnanoUno.AgregarElemento(Elemento2Enano1);
        
        //Mago
        Elementos Elemento1Mago = new Elementos("Espada1", 15, 2, "Espada?");
        Elementos Elemento2Mago = new Elementos("Escudo", 2, 8, "yqs");
        Mago MagoAtacante = new Mago("Enanito2", [Elemento1Mago] , 100);
        MagoAtacante.AgregarElemento(Elemento2Mago);
        
        //Mago ataca al enano
        EnanoUno.RecibirAtaqueDeEnano(MagoAtacante);
        
        //Verifico que la vida del enano atacado(1) sea la esperada
        Assert.AreEqual("Poner vida esperada", EnanoUno.Vida); //FALTA CALCULAR QUE DEBERÍA QUEDAR EN VIDA
    }

    [Test]
    public void TestEnanoSeCura()
    {
        Enanos EnanoDebil = new Enanos("Enanito", [] , 10);
        EnanoDebil.Curar();
        Assert.AreEqual(20, EnanoDebil.Vida);
    }
}