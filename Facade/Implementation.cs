using System.Diagnostics.Tracing;

namespace OrderService
{
    /// <summary>
    /// Subsystem Class
    /// </summary>
    public class OrderService
    {
        public bool HasEnoughOrders(int customerId)
        {
            // Does the customer have enough orders?
            // Fake claculation for demo purposes
            return (customerId > 5);
        }
    }   
    
    /// <summary>
    /// Subsystem Class
    /// </summary>
    public class CustomerDiscountBaseService
    {
        public double CalculateDiscountBase(int customerId)
        {
            // Fake calculation for demo purposes
            return customerId > 8 ? 10 : 20;
        }
    }
    
    /// <summary>
    /// Subsystem Class
    /// </summary>
    public class DayOfTheWeekFactorService
    {
        public double CalculateDayOfTheWeekFactor()
        {
            // Fake calculation for demo purposes
            switch (DateTime.UtcNow.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    return 0.8;
                default:
                    return 1.2;
            }
        }
    }

    /// <summary>
    /// Facade
    /// </summary>
    public class DiscountFacade
    {
        private readonly OrderService _orderService = new();
        private readonly CustomerDiscountBaseService _customerDiscountBaseService = new();
        private readonly DayOfTheWeekFactorService _dayOfTheWeekFactorService = new();

        public double CalculateDiscountPercentage(int customerId)
        {
            if (!_orderService.HasEnoughOrders(customerId))
            {
                return 0;
            }

            return _customerDiscountBaseService.CalculateDiscountBase(customerId)
                   * _dayOfTheWeekFactorService.CalculateDayOfTheWeekFactor();
        }
    }
}