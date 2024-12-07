namespace LogicLayer;

/// <summary>
/// Class to initialize a factory
/// </summary>
public class Initializer
{
    /// <summary>
    /// Init the factory
    /// </summary>
    /// <param name="f">factory to initialize</param>
    public static void InitFactory(Factory f)
    {
        f.RegisterFactory("bike", new BikeFactory());
        f.RegisterFactory("scooter", new ScooterFactory());
        f.RegisterFactory("car", new CarFactory());
    }

    public static void InitClient(ClientService service)
    {
        Dictionary<string, int> vehicules = new();
        vehicules["bike"] = 20;
        vehicules["scooter"] = 14;
        vehicules["car"] = 10;
        foreach(string v in vehicules.Keys)
        {
            service.InitNeeds(v, 0);
            service.InitProbs(v, vehicules[v]);
        }
    }
}
