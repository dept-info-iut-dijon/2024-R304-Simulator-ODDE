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
    public void TestInitFactory()
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

    [Fact]
    public void TestInitClient()
    {
        ClientService clientService = new ClientService();
        Initializer.InitClient(clientService);

        Assert.Equal(0, clientService.GetAskFor("bike"));
        Assert.Equal(0, clientService.GetAskFor("scooter"));
        Assert.Equal(0, clientService.GetAskFor("car"));
    }
}
