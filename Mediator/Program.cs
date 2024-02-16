using Mediator;

TrafficControlTower trafficControlTower = new TrafficControlTower();

var airplaneOne = new Airplane("AirplaneOne");
var airplaneTwo = new Airplane("AirplaneTwo");
var helicopterOne = new Helicopter("HelicopterOne");
var helicopterTwo = new Helicopter("HelicopterTwo");

trafficControlTower.Register(airplaneOne);
trafficControlTower.Register(airplaneTwo);
trafficControlTower.Register(helicopterOne);
trafficControlTower.Register(helicopterTwo);

helicopterOne.Send<Helicopter>("Hello, this is HelicopterOne. Airplanes suck!!!!");

// using Mediator;
//
// Console.Title = "Mediator";
//
// TeamChatRoom teamChatRoom = new();
//
// var sven = new Lawyer("Sven");
// var kenneth = new Lawyer("Kenneth");
// var ann = new AccountManager("Ann");
// var john = new AccountManager("John");
// var kylie = new AccountManager("Kylie");
//
// teamChatRoom.Register(sven);
// teamChatRoom.Register(kenneth);
// teamChatRoom.Register(ann);
// teamChatRoom.Register(john);
// teamChatRoom.Register(kylie);
//
// ann.Send("Hi everyone, can someone have a look at ABC123? I need help!");
// sven.Send("On it!");
//
// kenneth.Send("Ann", "Can we jump on a call?");
// kenneth.Send("Ann", "All good");
//
// // This is where the Type argument of 
// ann.SendTo<AccountManager>("The file was approved!");