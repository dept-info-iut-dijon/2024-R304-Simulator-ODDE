namespace LogicLayer.Observer;

public class Subject
{
    private List<IObserver> observers;

    public Subject()
    {
        observers = new List<IObserver>();
    }

    protected void NotifyMoneyChange(int money)
    {
        foreach (IObserver observable in observers)
        {
            observable.MoneyChange(money);
        }
    }

    /// <summary>
    /// Registe an observer
    /// </summary>
    /// <param name="obs">observer to registe</param>
    public void Register(IObserver obs)
    {
        observers.Add(obs);
    }

    /// <summary>
    /// Uneregiste an observer
    /// </summary>
    /// <param name="obs">Observer to unregiste</param>
    public void Unregister(IObserver obs)
    {
        observers.Remove(obs);
    }
}
