using Bridge;

var noCoupon = new NoCoupon();
var oneEuroCoupon = new OneEuroCoupon();

var meatBasedMenu = new MeatBasedMenu(noCoupon);
Console.WriteLine($"Meat based menu, no coupon: {meatBasedMenu.CalculatePrice()} euros");

meatBasedMenu = new MeatBasedMenu(oneEuroCoupon);
Console.WriteLine($"Meat based menu, one euro coupon: {meatBasedMenu.CalculatePrice()} euros");

var vegBasedMenu = new VegetarianMenu(noCoupon);
Console.WriteLine($"Vegetarian based menu, no coupon: {vegBasedMenu.CalculatePrice()} euros");

vegBasedMenu = new VegetarianMenu(oneEuroCoupon);
Console.WriteLine($"Vegetarian based menu, no coupon: {vegBasedMenu.CalculatePrice()} euros");
