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
}
