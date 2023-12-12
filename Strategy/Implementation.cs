namespace Strategy
{
    /// <summary>
    /// Strategy
    /// </summary>
    public interface IExportService
    {
        void Export(Order order);
    }
    
    /// <summary>
    /// ConcreteStrategy
    /// </summary>
    public class CSVExportService : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} to CSV...");
        }
    }
    
    /// <summary>
    /// ConcreteStrategy
    /// </summary>
    public class JSONExportService : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} to JSON...");
        }
    }
    
    /// <summary>
    /// ConcreteStrategy
    /// </summary>
    public class XMLExportService : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} to XML...");
        }
    }

    /// <summary>
    /// Context
    /// </summary>
    public class Order
    {
        public string Customer { get; set; }
        public int Amount { get; set; }
        public string? Description { get; set; }
        public string Name { get; set; }
        
        public Order(string name, string customer, int amount)
        {
            Name = name;
            Customer = customer;
            Amount = amount;
        }

        // public void Export()
        // {
        //     ExportService?.Export(this);
        // }
        
        // this is another way to implement - using a method parameter
        public void Export(IExportService exportService)
        {
            if (exportService is null)
            {
                throw new ArgumentNullException(nameof(exportService));
            }
            
            exportService.Export(this);
        }
    }
}
