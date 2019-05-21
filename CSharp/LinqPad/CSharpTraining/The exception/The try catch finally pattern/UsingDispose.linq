<Query Kind="Program" />

void Main()
{
	"Dispose".H1();
	using(var c1 = new MyClass())
	using(var c2 = new MyClass())
	{
		c1.Dump();
		c2.Dump();
		throw new Exception("Exception occured.");
	}
	
}

// Define other methods and classes here
public class MyClass : IDisposable
{
	public void Dispose()
	{
		"Dispose called".H4("red");
	}
}