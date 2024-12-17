namespace TestLogicLayer;

public class TestObserver
{

    [Fact]
    public void TestObserve()
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
    }
}
