using LogicLayer.Observer;

namespace TestLogicLayer;

public class SpyObserver : IObserver
{
    private int money;
    private int stock;
    private int material;
    private int freeEmployees;
    private int totalEmployees;


    public int Money { get => money; }
    public int Stock { get => stock; }
    public int Material { get => material; }
    public int FreeEmployees { get => freeEmployees; }
    public int TotalEmployees { get => totalEmployees; }


    public SpyObserver()
    {
        money = 0;
        stock = 0;
        material = 0;
        freeEmployees = 0;
        totalEmployees = 0;
    }

    public void MoneyChange(int money)
    {
       this.money = money;
    }

    public void StockChange(int stock)
    {
        this.stock = stock;
    }

    public void MaterialChange(int material)
    {
        this.material = material;
    }

    public void EmployeesChange(int free, int total)
    {
        freeEmployees = free;
        totalEmployees = total;
    }

    public void ClientNeedsChange(string type, int need)
    {
    }
}
