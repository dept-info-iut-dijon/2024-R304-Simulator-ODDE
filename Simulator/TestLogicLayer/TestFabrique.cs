using LogicLayer.Products;

namespace TestLogicLayer
{
    public class TestFabrique
    {
        [Fact]
        public void TestCreationVelo()
        {
            // Arrange
            Factory f = new Factory();
            f.RegisterFactory("bike", new BikeFactory());

            // Act
            Product produit = f.Create("bike").CreateProduct();

            // Assert
            Assert.NotNull(produit);
            Assert.IsType<Bike>(produit);
        }

        [Fact]
        public void TestCreationScooter()
        {
            // Arrange
            Factory f = new Factory();
            f.RegisterFactory("scooter", new ScooterFactory());

            // Act
            Product produit = f.Create("scooter").CreateProduct();

            // Assert
            Assert.NotNull(produit);
            Assert.IsType<Scooter>(produit);
        }

        [Fact]
        public void TestCreationVoiture()
        {
            // Arrange
            Factory f = new Factory();
            f.RegisterFactory("car", new CarFactory());

            // Act
            Product produit = f.Create("car").CreateProduct();


            // Assert
            Assert.NotNull(produit);
            Assert.IsType<Car>(produit);
        }
    }
}