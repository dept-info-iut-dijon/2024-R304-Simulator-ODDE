using LogicLayer.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLogicLayer;

public class TestInitializer
{

    [Fact]
    public void TestInit()
    {
        Factory f = new Factory();
        Initializer.InitFactory(f);

        Product bike = f.Create("bike").CreateProduct();

        // Assert
        Assert.NotNull(bike);
        Assert.IsType<Bike>(bike);

        Product scooter = f.Create("scooter").CreateProduct();

        // Assert
        Assert.NotNull(scooter);
        Assert.IsType<Scooter>(scooter);

        Product car = f.Create("car").CreateProduct();

        // Assert
        Assert.NotNull(car);
        Assert.IsType<Car>(car);
    }
}
