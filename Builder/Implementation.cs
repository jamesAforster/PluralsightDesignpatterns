using System.Text;

namespace Builder
{
    /// <summary>
    /// Product
    /// </summary>
    public class Car
    {
        private readonly List<string> _parts = new();
        private readonly string _carType;

        public Car(string carType)
        {
            _carType = carType;
        }

        public void AddPart(string part)
        {
            _parts.Add(part);
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            
            foreach (string part in _parts)
            {
                stringBuilder.Append($"Car of type {_carType} has part {part}");
            }

            return stringBuilder.ToString();
        }
    }

    /// <summary>
    /// Abstract Builder
    /// </summary>
    public abstract class CarBuilder
    // This provides abstract functionality for how to build a car
    {
        public Car Car { get; private set; }

        public CarBuilder(string carType)
        {
            Car = new Car(carType);
        }

        public abstract void BuildEngine();

        public abstract void BuildFrame();
    }

    /// <summary>
    /// Concrete Builder
    /// </summary>
    public class MiniBuilder : CarBuilder
    // This is a concrete implementation of how to build a car. It knows about how to build a certain type of car
    {
        public MiniBuilder() : base("Mini")
        {
        }

        public override void BuildEngine()
        {
            Car.AddPart("'1.5l 3-cylinder'");
        }

        public override void BuildFrame()
        {
            Car.AddPart("'Mini Cooper frame'");
        }
    }
    
    /// <summary>
    /// Concrete Builder
    /// </summary>
    public class BmwBuilder : CarBuilder 
    // This is a concrete implementation of how to build a car. It knows about how to build a certain type of car
    {
        public BmwBuilder() : base("BMW")
        {
        }

        public override void BuildEngine()
        {
            Car.AddPart("'2l 6-cylinder'");
        }

        public override void BuildFrame()
        {
            Car.AddPart("'BMW S-Class'");
        }
    }

    /// <summary>
    /// Director
    /// </summary>
    public class Garage
    // This class is the client class which implements the Builder
    {
        private CarBuilder? _builder;
        public void Construct(CarBuilder builder)
        {
            _builder = builder;

            _builder.BuildEngine();
            _builder.BuildFrame();
        }
        
        public void Show()
        {
            Console.WriteLine(_builder?.Car.ToString());
        }
    }
}
