namespace AbstractFactory
{
    /// <summary>
    /// Abstract Factory
    /// </summary>
    public interface IShoppingCartPurchaseFactory
    // This is the interface for constructing different services depending on where we are 
    {
        IDiscountService CreateDiscountService();
        IShippingCostsService CreateShippingCostsService();
    }

    /// <summary>
    /// Abstract Product
    /// </summary>
    public interface IDiscountService
    // Interface for a service to  give us discounts
    {
        int DiscountPercentage { get; }
    }

    /// <summary>
    /// Concrete Product
    /// </summary>
    public class BelgiumDiscountService : IDiscountService
    // Implementation of a discount service for belgium
    {
        public int DiscountPercentage => 20;
    }

    /// <summary>
    /// Concrete Product
    /// </summary>
    public class FranceDiscountService : IDiscountService
    // Implementation of a discount service for France 
    {
        public int DiscountPercentage => 10;
    }
    
    /// <summary>
    /// Abstract Product
    /// </summary>
    public interface IShippingCostsService
    // Interface for a service to give us shipping costs
    {
        decimal ShippingCosts { get; }
    }

    /// <summary>
    /// Concrete Product
    /// </summary>
    class BelgiumShippingCostsService : IShippingCostsService
    // Implementation of shipping cost service for Belgium
    {
        public decimal ShippingCosts => 20;
    }

    /// <summary>
    /// Concrete Product
    /// </summary>
    class FranceShippingCostsService : IShippingCostsService
    // Implementation of shipping cost service for France
    {
        public decimal ShippingCosts => 25;
    }

    
    /// <summary>
    /// Concrete Factory
    /// </summary>
    public class BelgiumShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
    // This implements the factory interface and knows which services to create for Belgium 
    {
        public IDiscountService CreateDiscountService()
        {
            return new BelgiumDiscountService();
        }

        public IShippingCostsService CreateShippingCostsService()
        {
            return new BelgiumShippingCostsService();
        }
    }
    
    /// <summary>
    /// Concrete Factory
    /// </summary>
    public class FranceShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory 
    // This implements the factory interface and knows which services to create for France 
    {
        public IDiscountService CreateDiscountService()
        {
            return new FranceDiscountService();
        }

        public IShippingCostsService CreateShippingCostsService()
        {
            return new FranceShippingCostsService();
        }
    }

    /// <summary>
    /// Client Class
    /// </summary>
    public class ShoppingCart
    // Our client, the ShoppingCart, does not need to know about which country it is involved in calculating the costs for 
    // It will, when it is instantiated, call the factory it has been provided with in the constructor
    // The Factory will then provide the services necessary
    // Responsibility for deciding which services we need has been delegated to the IOC, or whichever class instantiates this one
    {
        private readonly IDiscountService _discountService;
        private readonly IShippingCostsService _shippingCostsService;
        private int _orderCosts;

        // Constructor
        public ShoppingCart(IShoppingCartPurchaseFactory factory)
        {
            _discountService = factory.CreateDiscountService();
            _shippingCostsService = factory.CreateShippingCostsService();
            
            // Assuming total cost of all items is 200
            _orderCosts = 200;
        }

        public void CalculateCosts()
        {
            Console.WriteLine($"Total costs = " + 
                              $"{ _orderCosts - (_orderCosts / 100 * _discountService.DiscountPercentage) + _shippingCostsService.ShippingCosts }");
        }
    }
}
