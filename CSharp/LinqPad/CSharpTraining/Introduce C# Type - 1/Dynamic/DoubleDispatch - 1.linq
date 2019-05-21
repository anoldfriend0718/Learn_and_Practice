<Query Kind="Program" />

void Main()
{
	"Simple method".H1();
	Shape shape = new Square();
	SimpleMethod(shape);
}

public void SimpleMethod(Shape shape)
{
	Print(shape);
	
	if(shape is Circle)
	{
		"Simple Circle".Dump();
	}
	else if(shape is Square)
	{
		"Simple Square".Dump();
	}
}

public void Print(Shape s)
{"shape".Dump();}

public void Print(Circle s)
{"Circle".Dump();}

public void Print(Square s)
{"Square".Dump();}


public abstract class Shape {}
public class Circle : Shape {}
public class Square : Shape {}