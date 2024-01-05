using FactoryMethod;

Console.Title = "FactoryMethod";

var factories = new List<DiscountFactory>
{
    new CodeDiscountFactory(Guid.NewGuid()),
    new CountryDiscountFactory("BE")
};

foreach (var factory in factories)
{
    // Imagine the client has called the code below.
    // The client will take in an instance of IDiscountFactory, and doesn't need to know what type of factory it is.
    // The client will call the CreateDiscountService method, and will get an instance of the DiscountService.
    // The client will then call the DiscountPercentage property on the DiscountService, and will get the correct value.
    // The client doesn't need to know what type of DiscountService it is, it just needs to know that it is a DiscountService.
    // The code which calls the client will be responsible for passing in the correct factory.
    var discountService = factory.CreateDiscountService();
    Console.WriteLine($"Percentage {discountService.DiscountPercentage} " + 
                      $"coming from {discountService}");
}

Console.ReadKey();