<Query Kind="Program" />

void Main()
{
	"EIMI".H1();
	Interface1 c1 = new MyClass();
	Interface2 c2 = (Interface2)c1;
	MyClass c3 = (MyClass)c1;
	
	c1.Run();
	c2.Run();
	c3.Run();
}

// Define other methods and classes here
public interface Interface1
{
	void Run();
}

public interface Interface2
{
	void Run();
}

public class MyClass : Interface1, Interface2
{
	public void Run()
	{
		"Default Implementation".Dump();
	}
	
	void Interface1.Run()
	{
		"Interface1 Implementation".Dump();
	}
	
	void Interface2.Run()
	{
		"Interface2 Implementation".Dump();
	}	
}