<Query Kind="Program" />

void Main()
{
	"Use dynamic type".H1();
	Shape shape = new Square();
	UseDynamic(shape);
}

public void UseDynamic(Shape shape)
{
	new DynamicAccess().Access((dynamic)shape);
}

public class DynamicAccess
{
	public void Access(dynamic shape)
	{
		Access(shape);
	}
	
	private void Access(Shape shape)
	{
		"Dynamic shape".Dump();
	}	
	
	private void Access(Circle shape)
	{
		"Dynamic circle".Dump();
	}
	
	private void Access(Square shape)
	{
		"Dynamic square".Dump();
	}	
}


public abstract class Shape {}
public class Circle : Shape {}
public class Square : Shape {}