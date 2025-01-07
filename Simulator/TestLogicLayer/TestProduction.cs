using LogicLayer.Products;

namespace TestLogicLayer;

public class TestProduction
{
    private Production CreateProd()
    {
        return new Production(new Bike(), 10);
    }

    [Fact]
    public void TestStartProduction()
    {
        SpyObserver spy = new SpyObserver();
        Production production = CreateProd();
        production.Register(spy);
        spy.ProductStart(production.Product);
        Assert.NotEmpty(spy.Products);
        Assert.Single(spy.Products);
    }

    [Fact]
    public void TestFinishProduction()
    {
        SpyObserver spy = new SpyObserver();
        Production production = CreateProd();
        production.Register(spy);
        spy.ProductStart(production.Product);
        spy.ProductionDone(production.Product);
        Assert.Empty(spy.Products);
    }
}
