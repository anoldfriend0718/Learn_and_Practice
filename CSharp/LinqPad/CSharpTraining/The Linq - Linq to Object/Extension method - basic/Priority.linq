<Query Kind="Program" />

void Main()
{
	"Extension Method Priority".H1();
	var p = new Parent();
	p.Run();
	
	var c = new Child();
	c.Run();
	
	Parent pc = new Child();
	pc.Run();
	
	GrandSon gs = new GrandSon();
	gs.Run();
}

public class Parent
{}

public class Child : Parent
{
	//public void Run() {"Actual Child Call".Dump();}
}

public class GrandSon: Child
{}

public static class MyExtension
{
	public static void Run(this Parent @this)
	{
		"Parent Extension Method".Dump();
	}
	
	public static void Run(this Child @this)
	{
		"Child Extension Method".Dump();
	}	
}