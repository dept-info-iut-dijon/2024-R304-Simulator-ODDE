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
    
    protected void NotifyMaterialChange(int material)
    {
        foreach (IObserver observable in observers)
        {
            observable.MaterialChange(material);
        }
    }
    
    protected void NotifyStockChange(int stock)
    {
        foreach (IObserver observable in observers)
        {
            observable.StockChange(stock);
        }
    }


    protected void NotifyEmployeesChange(int free, int total)
    {
        foreach (IObserver observable in observers)
        {
            observable.EmployeesChange(free, total);
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
