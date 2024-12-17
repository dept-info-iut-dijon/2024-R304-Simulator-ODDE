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
    }
}
