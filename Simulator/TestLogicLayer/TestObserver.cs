namespace TestLogicLayer;

public class TestObserver
{

    [Fact]
    public void TestObserveMoney()
    {
        SpyObserver spy = new SpyObserver();
        Enterprise enterprise = new Enterprise(new Parameters() { MonthTime = 10 });
        enterprise.Hire();
        enterprise.Register(spy);
        enterprise.PayEmployees();
        Thread.Sleep(20);
        Assert.True(spy.Money == enterprise.Money);


        enterprise.BuyMaterials();
        Thread.Sleep(20);
        Assert.True(spy.Money == enterprise.Money);

        enterprise.Dismiss();
        Thread.Sleep(20);
        Assert.True(spy.Money == enterprise.Money);
        enterprise.Dispose();
    }

    [Fact]
    public void TestObserveStock()
    {
        SpyObserver spy = new SpyObserver();
        Enterprise enterprise = new Enterprise(new Parameters() { MonthTime = 10 });
        enterprise.Register(spy);
        enterprise.BuyMaterials();
        Thread.Sleep(20);
        Assert.True(spy.Stock == enterprise.TotalStock);
        enterprise.Dispose();
    }

    [Fact]
    public void TestObserveEmploye()
    {
        SpyObserver spy = new SpyObserver();
        Enterprise enterprise = new Enterprise(new Parameters() { MonthTime = 10 });
        enterprise.Register(spy);
        enterprise.Hire();
        enterprise.MakeProduct("bike");

        Thread.Sleep(20);
        Assert.True(spy.TotalEmployees == enterprise.Employees);
        Assert.True(spy.FreeEmployees == enterprise.FreeEmployees);
        enterprise.Dispose();
    }
}
