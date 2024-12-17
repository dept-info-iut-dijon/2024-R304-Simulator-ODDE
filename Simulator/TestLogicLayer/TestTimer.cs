namespace TestLogicLayer
{
    public class TestTimer
    {

        [Fact]
        public void TestEndMonth()
        {
            Parameters parameters = new Parameters()
            {
                MonthTime = 200
            };
            Enterprise enterprise = new Enterprise(parameters);
            int totalMoney = enterprise.Money;
            enterprise.Hire();
            enterprise.Hire();
            Thread.Sleep(enterprise.MonthTime * 2);
            int mon = enterprise.Money;

            Assert.True(enterprise.Money < totalMoney);
            enterprise.Dispose();
        }
    }
}
