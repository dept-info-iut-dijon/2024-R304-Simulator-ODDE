// CarFactory.cs

using LogicLayer.Products;

namespace LogicLayer
{
    public class CarFactory : IProductFactory
    {
        public Product CreateProduct()
        {
            return new Car();
        }
    }
}