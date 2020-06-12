<Query Kind="Program" />

void Main()
{
    // Display powers of 2 up to the exponent of 8:
    foreach (int i in Power(2, 8))
    {
        Console.Write("{0} ", i);
    }
}

public static System.Collections.Generic.IEnumerable<int> Power(int number, int exponent)
{
    int result = 1;

    for (int i = 0; i < exponent; i++)
    {
        result = result * number;
        yield return result;
		Console.WriteLine($"After Yield");
    }
}

// Output: 2 4 8 16 32 64 128 256
//Remark:
//The above example has a yield return statement that's inside a for loop. 
//Each iteration of the foreach statement body in the Main method creates a call to the Power iterator function.
//Each call to the iterator function proceeds to the next execution of the yield return statement, 
//which occurs during the next iteration of the for loop.