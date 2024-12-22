namespace LogicLayer.Observer
{
    public interface IObserver
    {
        /// <summary>
        /// Notify change of money
        /// </summary>
        /// <param name="money">amount of money</param>
        void MoneyChange(int money);

        /// <summary>
        /// Notify change of stock
        /// </summary>
        /// <param name="stock">number of stock</param>
        void StockChange(int stock);

        /// <summary>
        /// Notify change of material
        /// </summary>
        /// <param name="material">number of material</param>
        void MaterialChange(int material);


        /// <summary>
        /// Notify change of employees
        /// </summary>
        /// <param name="free">number of employees free</param>
        /// <param name="total">number of employees total</param>
        void EmployeesChange(int free, int total);

        /// <summary>
        /// change of client's needs
        /// </summary>
        /// <param name="type">type of product</param>
        /// <param name="need">need of product</param>
        void ClientNeedsChange(string type, int need);

        /// <summary>
        /// change of buy's client
        /// </summary>
        /// <param name="type"></param>
        void ClientBuyChange(string type);

        /// <summary>
        /// when a production is done 
        /// </summary>
        /// <param name="productDone">product done</param>
        void ProductionDone(Product productDone);

        /// <summary>
        /// product's start 
        /// </summary>
        /// <param name="product">production started</param>
        void ProductStart(Product product);
    }
}
