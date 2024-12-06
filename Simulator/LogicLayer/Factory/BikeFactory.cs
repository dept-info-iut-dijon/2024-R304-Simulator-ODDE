// BikeFactory.cs

using LogicLayer.Products;

namespace LogicLayer
{
    public class BikeFactory : IProductFactory
    {
        public Product CreateProduct()
        {
            return new Bike();
        }
    }
}