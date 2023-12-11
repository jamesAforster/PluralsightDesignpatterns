namespace FactoryMethod
{
    /// <summary>
    /// Abstract Product
    /// </summary>
    public abstract class DiscountService // this is an abstract idea of what the client needs. Ultimately, the discount percentage.
    {
        public abstract int DiscountPercentage { get; } // Abstract as we want this class to be inherited from and implemented
        
        public override string ToString() => GetType().Name;
    }

    /// <summary>
    /// Concrete Product
    /// </summary>
    public class CountryDiscountService : DiscountService
    // this is a concrete implementation of the above, to return a discount based on tenant
    {
        private readonly string _countryIdentifier;

        public CountryDiscountService(string countryIdentifier)
        {
            _countryIdentifier = countryIdentifier;
        }

        public override int DiscountPercentage
        {
            get
            {
                switch (_countryIdentifier)
                {
                    case "BE":
                        return 20;
                    default:
                        return 10;
                }
            }
        }
    }
    
    /// <summary>
    /// Concrete Product
    /// </summary>
    public class CodeDiscountService : DiscountService 
    // this is a concrete implementation of the above, to return a discount based on GUID
    {
        private readonly Guid _code;

        public CodeDiscountService(Guid code)
        {
            _code = code;
        }

        public override int DiscountPercentage
        {
            get => 15;
        }
    }
    // when the two classes above are instantiated, the client needs to know what to create
    
    /// <summary>
    /// Abstract Creator
    /// </summary>
    public abstract class DiscountFactory
    {
        public abstract DiscountService CreateDiscountService();
    }

    /// <summary>
    /// Concrete Creator
    /// </summary>
    public class CountryDiscountFactory : DiscountFactory // This factory creates a CountryDiscountService
    // this returns an instance of the CountryDiscountService
    {
        private string _countryIdentifier;

        public CountryDiscountFactory(string countryIdentifier)
        {
            _countryIdentifier = countryIdentifier;
        }

        public override DiscountService CreateDiscountService()
        {
            return new CountryDiscountService(_countryIdentifier);
        }
    }
    
    /// <summary>
    /// Concrete Creator
    /// </summary>
    public class CodeDiscountFactory : DiscountFactory // This factory creates a CountryDiscountService
    // this returns an instance of the CodeDiscountService
    {
        private readonly Guid _code;

        public CodeDiscountFactory(Guid code)
        {
            _code = code;
        }

        public override DiscountService CreateDiscountService()
        {
            return new CodeDiscountService(_code);
        }
    }
}
