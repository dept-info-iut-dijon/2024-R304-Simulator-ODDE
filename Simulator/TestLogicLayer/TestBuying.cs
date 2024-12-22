namespace TestLogicLayer;

public class TestBuying
{

    [Fact]
    public void TestBuyingEnterprise()
    {
        Parameters p = new() { TimeSlice = 10, WeekTime = 10 };
        Enterprise enterprise = new Enterprise(p);

        enterprise.Hire();
        enterprise.MakeProduct("bike");
        Thread.Sleep(p.WeekTime * 2);
        Assert.Equal(0, enterprise.GetStock("bike"));
    }
}
