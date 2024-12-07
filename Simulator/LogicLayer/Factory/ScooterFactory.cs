// ScooterFactory.cs

using LogicLayer.Products;

namespace LogicLayer
{
    public class ScooterFactory : IProductFactory
    {
        public Product CreateProduct()
        {
            return new Scooter();
        }
    }
}