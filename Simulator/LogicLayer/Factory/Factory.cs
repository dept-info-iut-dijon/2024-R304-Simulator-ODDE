namespace LogicLayer;

public class Factory
{
    private Dictionary<string, IProductFactory> _factories;

    public Factory()
    {
        _factories = new Dictionary<string, IProductFactory>();
    }
    
    /// <summary>
    /// Registre new element to dictionnary
    /// </summary>
    /// <param name="type">type of product</param>
    /// <param name="factory">factory of product</param>
    public void RegisterFactory(string type, IProductFactory factory)
    {
        _factories.Add(type, factory);
    }

    /// <summary>
    /// Unregistre new element to dictionnary
    /// </summary>
    /// <param name="type">type of product</param>
    public void UnregisterFactory(string type)
    {
        _factories.Remove(type);
    }
    
    /// <summary>
    /// Create the product
    /// </summary>
    /// <param name="type">type of product</param>
    /// <returns>the product</returns>
    /// <exception cref="ProductUnknown">product is unknow</exception>
    public IProductFactory Create(string type)
    {
        if(_factories.ContainsKey(type))
        {
            return _factories[type];
        }
        else
        {
            throw new ProductUnknown();
        }
    }
}