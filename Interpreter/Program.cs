using Interpreter;

Console.Title = "Interpreter";

var expressions = new List<RomanExpression>
{
    new RomanHundredExpression(),
    new RomanTenExpression(),
    new RomanOneExpression(),
};

// var context = new RomanContext(5);
//
// foreach (var expression in expressions)
// {
//     expression.Interpret(context);
// }
//
// Console.WriteLine($"Translating Arabic numerals to Roman numerals: {context.Output}");
//
// context = new RomanContext(81);
//
// foreach (var expression in expressions)
// {
//     expression.Interpret(context);
// }

// Console.WriteLine($"Translating Arabic numerals to Roman numerals: {context.Output}");

var context = new RomanContext(733);

foreach (var expression in expressions)
{
    expression.Interpret(context);
}

Console.WriteLine($"Translating Arabic numerals to Roman numerals: {context.Output}");

Console.ReadKey();
