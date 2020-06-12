<Query Kind="Program" />

void Main()
{
	"Visitor pattern".H1();
	Shape shape = new Square();
	DoubleDispatch(shape);
}

public void DoubleDispatch(Shape shape)
{
	var visitor = new MyVisitor();
	shape.Accept(visitor);
}

public abstract class Shape : IAccessible
{
	public abstract void Accept(IVisitor visitor);
	
}
public class Circle : Shape
{
	public override void Accept(IVisitor visitor)
	{
		visitor.Visit(this);
	}
	
}
public class Square : Shape
{
	public override void Accept(IVisitor visitor)
	{
		visitor.Visit(this);
	}	
}

public interface IVisitor
{
	void Visit(Shape accessable);
	
	void Visit(Circle accessable);
	
	void Visit(Square accessable);
}

public class MyVisitor : IVisitor
{
	public void  Visit(Shape accessable)
	{
		"can't be".Dump();
	}
	
	public void Visit(Circle accessable)
	{
		"Double dispatch Circle".Dump();
	}
	
	public void Visit(Square accessable)
	{
		"Double dispatch Square".Dump();
	}
}

public interface IAccessible
{
	void Accept(IVisitor visitor);
}