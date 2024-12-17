using LogicLayer.Observer;

namespace TestLogicLayer;

public class SpyObserver : IObserver
{
    private int money;

    public int Money { get => money; }

    public SpyObserver()
    {
        money = 0;
    }

    public void MoneyChange(int money)
    {
       this.money = money;
    }
}
