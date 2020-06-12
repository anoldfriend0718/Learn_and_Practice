<Query Kind="Program" />

void Main()
{
	"Overload".H1();

	Container container = new Container();

	"Use proper static type".H3("blue");
	object o = new object();
	Parent p = new Parent();
	Child c = new Child();
	container.Run(o);
	container.Run(p);
	container.Run(c);

	"Use parent static type".H3("blue");
	object pp = new Parent();
	Parent cc = new Child();
	container.Run(pp);
	container.Run(cc);

}

public class Parent
{ }
public class Child : Parent
{ }

public class Container
{
	public void Run(object obj)
	{
		"Object Called".Dump();
	}

	public void Run(Parent p)
	{
		"Parent Called".Dump();
	}

	public void Run(Child p)
	{
		"Child Called".Dump();
	}

	// You can not do this
	// public int Run(Parent p) {}
}

