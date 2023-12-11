using Builder;

var garage = new Garage();

var miniBuilder = new MiniBuilder();
var bmwBuilder = new BmwBuilder();

garage.Construct(miniBuilder);
garage.Show();

garage.Construct(bmwBuilder);
garage.Show();

Console.ReadKey();
