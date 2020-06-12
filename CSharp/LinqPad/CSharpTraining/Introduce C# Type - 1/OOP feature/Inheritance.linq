<Query Kind="Program" />

void Main()
{
	"Inheritance".H1();

	var c1 = new ChildWithoutConstructor();
	c1.Dump();
	var c2 = new ChildWithConstructorButNotCallBase();
	c2.Dump();
	var c3 = new ChildWithParamConstructorButNotCallBase(3);
	c3.Dump();
	var c4 = new ChildWithParamConstructorAndCallBase(4);
	c4.Dump();

	(c4 is Parent).Dump("Is a");
	(c4 as Parent).Dump("Type Conversion");
	((object)c4 as ChildWithoutConstructor).Dump("Failed convert");
	
	typeof(Parent).IsAssignableFrom(typeof(ChildWithParamConstructorAndCallBase)).Dump("Query Type conversion");
}

public class Parent
{
	public int ParentProp { get; set; }

	public Parent()
	{
		ParentProp = 1;
		"Parent constructor finished".Dump();
	}

	public Parent(int arg)
	{
		ParentProp = arg;
		"Parent constructor with parameter finished".Dump();
	}
}

public class ChildWithoutConstructor : Parent
{ }
public class ChildWithConstructorButNotCallBase : Parent
{
	public int ChildProp { get; set; }
	public ChildWithConstructorButNotCallBase()
	{
		ChildProp = 2;
	}
}

public class ChildWithParamConstructorButNotCallBase : Parent
{
	public int ChildProp { get; set; }
	public ChildWithParamConstructorButNotCallBase(int arg)
	{
		ChildProp = arg;
	}
}

public class ChildWithParamConstructorAndCallBase : Parent
{
	public int ChildProp { get; set; }
	public ChildWithParamConstructorAndCallBase(int arg) : base(arg)
	{
		ChildProp = arg;
	}
}

