public static class Playground
{
    public static void Start()
    {
        MyClass firstA = new MyClass(7); // The variable "first" is holding a reference to the object 
        MyClass secondA = firstA; // The variable "second" is holding a reference to the same object 
        secondA.Value = 5; // So, changing either of the properties of either variable will change the same object
        Console.WriteLine(firstA.Value);
        Console.WriteLine(secondA.Value);

        MyStruct firstB = new MyStruct(7); // Structs are value types, so firstB holds the value
        MyStruct secondB = firstB; // as we have passed by value, we have copied the data across, so now we have two
        secondB.Value = 5; 
        
        Console.WriteLine(firstB.Value);
        Console.WriteLine(secondB.Value);
    }
}

public class MyClass
{
    public int Value;

    public MyClass(int v)
    {
        Value = v;
    }
}

public struct MyStruct
{
    public int Value;

    public MyStruct(int v)
    {
        Value = v;
    }
}

public class StackAndHeap
{
    public void Go()
    {
        int a = 5; // This is a value type, so "a" (on the stack) points to the value directly, and will be stored on the stack.
        string b = "123"; // This is a reference type, so "b" (on the stack) points to the reference to the object. The object itself is stored on the heap.
        string c = b; // This is a reference type, so "c" (on the stack) points to the same  reference as "b".
    }
}
