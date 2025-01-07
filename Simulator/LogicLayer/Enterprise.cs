using LogicLayer.Observer;
using System.Diagnostics;

namespace LogicLayer
{
    /// <summary>
    /// Enterprise simulation
    /// </summary>
    public class Enterprise : Subject, IDisposable, IObserver
    {
        #region associations
        private Workshop workshop;
        private Stock stock;
        private ClientService clients;
        private Parameters parameters;
        #endregion

        #region Properties 
        /// <summary>
        /// Gets base amout of time (ms) 
        /// </summary>
        public int TimeSlice => parameters.TimeSlice;
        /// <summary>
        /// Gets amount of time for simulate a month (in ms)
        /// </summary>
        public int MonthTime => parameters.MonthTime;

        /// <summary>
        /// Gets amout of time for simulate a week, in ms
        /// </summary>
        public int WeekTime => parameters.WeekTime;

        /// <summary>
        /// Gets the amount of money that enterprise disposes
        /// </summary>
        public int Money { get => money; }
        private int money;

        private int materials;
        /// <summary>
        /// Gets the amount of materials that enterprise disposes
        /// </summary>
        public int Materials { get => materials; }

        private int employees;
        /// <summary>
        /// Gets the number of employees
        /// </summary>
        public int Employees { get => employees; }

        /// <summary>
        /// Gets the number of free employees (they can work)
        /// </summary>
        public int FreeEmployees
        {
            get => employees - EmployeesWorkshop;
        }
       
        /// <summary>
        /// Gets the number of employees working in the workshop
        /// </summary>
        public int EmployeesWorkshop { get => workshop.NbEmployees; } 

        /// <summary>
        /// Gets the total amount of stock
        /// </summary>
        public int TotalStock { get => stock.TotalStock; }

        /// <summary>
        /// Get the factory
        /// </summary>
        public Factory Factory { get => factory; }
        private Factory factory;

        /// <summary>
        /// Get the timer
        /// </summary>
        public System.Threading.Timer Timer { get => Timer; }
        private System.Threading.Timer timer;
        #endregion

        #region Constructors

        /// <summary>
        /// Initialize the enterprise
        /// </summary>
        public Enterprise(Parameters? parameters = null) : base()
        {
            if(parameters == null)
                parameters = new Parameters();
            this.parameters = parameters;
            money = 300000;
            employees = 0;
            materials = 100;  
            workshop = new Workshop(parameters.TimeSlice);
            stock = new Stock(parameters.MaxStock);
            clients = new ClientService();
            clients.Register(this);
            Initializer.InitClient(clients);
            factory = new Factory();
            Initializer.InitFactory(factory);
            timer = new Timer(EndOfMonth);
            timer.Change(0, MonthTime);
            Notify();
        }
        #endregion

        #region methods
        /// <summary>
        /// Buy some materials
        /// </summary>
        /// <exception cref="NotEnoughMoney">If insufisant funds</exception>
        public void BuyMaterials()
        {
            int cost = parameters.Materials * parameters.CostOfMaterials;
            if (money < cost)
                throw new NotEnoughMoney();
            money -= cost;
            materials += parameters.Materials;
            Notify();
        }

        /// <summary>
        /// Hire a new emloyee
        /// </summary>        
        public void Hire()
        {
            ++employees;
            Notify();
        }

        /// <summary>
        /// DIsmiss an employee
        /// </summary>
        /// <exception cref="NoEmployee">If no employee to dismiss</exception>
        /// <exception cref="NotEnoughMoney">If not enough money to pay the bonus</exception>
        /// <exception cref="EmployeeWorking">If all employees worked, no dismiss is possible</exception>
        public void Dismiss()
        {
            if (employees < 1) throw new NoEmployee();
            int cost = parameters.Bonus;
            if (money < cost)
                throw new NotEnoughMoney();
            if (FreeEmployees < 1)
                throw new EmployeeWorking();
            money -= cost;
            employees--;
            Notify();
        }

        /// <summary>
        /// Start a product production
        /// </summary>
        /// <param name="type">a string identifying kind of product</param>
        /// <exception cref="ProductUnknown">the type is unknown</exception>
        /// <exception cref="NotEnoughMaterials">Not enough materials to build</exception>
        /// <exception cref="NoEmployee">Not enough employee to build</exception>
        public void MakeProduct(string type)
        {
            Product p = factory.Create(type).CreateProduct();
            // test if the product can be build
            if (materials < p.MaterialsNeeded)
                throw new NotEnoughMaterials();
            if (employees - EmployeesWorkshop < p.EmployeesNeeded)
                throw new NoEmployee();

            materials -= p.MaterialsNeeded; // consume materials
            // start the building...
            workshop.StartProduction(p, this);
            Notify(productStarted : p);
        }

        /// <summary>
        /// Update the productions & the stock
        /// </summary>
        /// <exception cref="UnableToStock">If stock is full</exception>
        public void UpdateProductions()
        {
            // update informations about productions
            var list = workshop.ProductsDone(); 
            // add finish products in stock
            foreach(var product in list)
            {
                Notify(productDone : product);
            }
        }

        /// <summary>
        /// Get the numbers of products of a type workshop build
        /// </summary>
        /// <param name="v">kind of product</param>
        /// <returns>number of products building</returns>        
        public int GetProduction(string v)
        {
            return workshop.InProduction(v);
        }

        /// <summary>
        /// Gets the number of products stocked
        /// </summary>
        /// <param name="v">type of product</param>
        /// <returns>number stocked</returns>
        public int GetStock(string v)
        {
            return stock.GetNbOfType(v);
        }

        /// <summary>
        /// Pay all the employees
        /// </summary>
        /// <exception cref="NotEnoughMoney">if money is not enough !</exception>
        public void PayEmployees()
        {
            int cost = employees * parameters.Salary;
            if (cost > money)
                throw new NotEnoughMoney();
            money -= cost;
            Notify();
        }

        /// <summary>
        /// Update the buying status
        /// </summary>
        public void UpdateBuying()
        {            
            if(clients.WantToBuy("bike"))
            {
                TrySell("bike");
            }
            else if(clients.WantToBuy("scooter"))
            {
                TrySell("scooter");
            }
            else if(clients.WantToBuy("car"))
            {
                TrySell("car");
            }
        }

        private void TrySell(string type)
        {
            Product? p = stock.Find(type);
            if(p!=null)
            {
                stock.Remove(p);
                money += p.Price;
                clients.Buy(type);
                Notify();
            }
        }

        /// <summary>
        /// update client needs
        /// </summary>
        public void UpdateClients()
        {            
            clients.UpdateClients();
        }
        
        /// <summary>
        /// Get clients needs
        /// </summary>
        /// <param name="type">type of product clients wanted</param>
        /// <returns>number of potential clients</returns>
        /// <exception cref="ProductUnknown">If type unknown</exception>
        public int GetAskClients(string type)
        {
            return clients.GetAskFor(type);
        }

        private void EndOfMonth(object? state)
        {
            PayEmployees();
            UpdateClients();
        }

        private void Notify(Product? productStarted = null, Product? productDone = null)
        {
            MoneyChange(money);
            StockChange(stock.TotalStock);
            MaterialChange(materials);
            EmployeesChange(FreeEmployees, employees);
            ClientNeedsChange("bike", clients.GetAskFor("bike"));
            ClientNeedsChange("scooter", clients.GetAskFor("scooter"));
            ClientNeedsChange("car", clients.GetAskFor("car"));
            ClientBuyChange("bike");
            ClientBuyChange("scooter");
            ClientBuyChange("car");
            if (productStarted != null) ProductStart(productStarted);
            if (productDone != null) ProductionDone(productDone);
        }

        public void Dispose()
        {
            timer.Dispose();
        }

        public void MoneyChange(int money)
        {
            base.NotifyMoneyChange(money);
        }

        public void StockChange(int stock)
        {
            base.NotifyStockChange(stock);
        }

        public void MaterialChange(int material)
        {
            base.NotifyMaterialChange(material);
        }

        public void EmployeesChange(int free, int total)
        {
            base.NotifyEmployeesChange(FreeEmployees, employees);
        }

        public void ClientNeedsChange(string type, int need)
        {
            base.NotifyNeedsChange(type, need);
        }

        public void ClientBuyChange(string type)
        {
            base.NotifyBuyChange(type);
        }

        public void ProductionDone(Product productDone)
        {
            stock.Add(productDone);
            workshop.Remove(productDone);
            base.NotifyProductionDone(productDone);
        }
       
        public void ProductStart(Product product)
        {
            base.NotifyProductionStart(product);
        }

        #endregion



    }
}