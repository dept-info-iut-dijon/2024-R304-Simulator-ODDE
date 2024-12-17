namespace LogicLayer.Observer
{
    public interface IObserver
    {
        /// <summary>
        /// Notify change of money
        /// </summary>
        /// <param name="money">amount of money</param>
        void MoneyChange(int money);
    }
}
