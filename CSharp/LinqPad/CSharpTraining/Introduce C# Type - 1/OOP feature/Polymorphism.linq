<Query Kind="Program" />

void Main()
{
	"Polymorphism".H1();

	"Use Child static type".H3("blue");
	Child c = new Child();
	c.RunInParent();
	c.Run();

	"Use Parent static type".H3("blue");
	Parent p = new Child();
	p.RunInParent();
	p.Run();
	p = new AnotherChild();
	p.RunInParent();
	p.Run();
}

public class Parent
{
	public void RunInParent()
	{
		"RunInParent".Dump();
	}

	public virtual void Run()
	{
		"virtual Run in Parent".Dump();
	}
}

public class Child : Parent
{
	public override void Run()
	{
		"override Run in Child".Dump();
	}
}

public class AnotherChild : Parent
{
	public override void Run()
	{
		"Another Child override Run method".Dump();
	}
}