<Query Kind="Program" />

void Main()
{
	"Interface implementation".H1();
	Interface1 c = new MyClass2();
	c.Run();
	
	Interface1 c2 = new MyClass4();
	c2.Run();
}

public interface Interface1
{
	void Run();
}

public class MyClass1 : Interface1
{
	public void Run()
	{
		"MyClass1 implementation".Dump();
	}
}

public class MyClass2 : MyClass1
{
	public void Run()
	{ 
		"MyClass2 implementation".Dump();
	}
}

public class MyClass3 : Interface1
{
	public virtual void Run()
	{
		"MyClass3 implementation".Dump();
	}
}

public class MyClass4 : MyClass3
{
	public override void Run()
	{
		"MyClass4 implementation".Dump();
	}
}