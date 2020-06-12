<Query Kind="Program" />

void Main()
{
	"Generic class".H1();
	// closed type
	var c1 = new Container<int>(1);
	var c2 = new Container<string>("a");
	
	c1.Dump();
	c2.Dump();
	
	@"see more complex sample in Functional\Either folder".Info();
}

// open type
public class Container<T>
{
	private T _value;
	
	public Container(T value)
	{
		_value = value;
	}
	
	public T Value 
	{
		get { return _value;}
	}
	
	public override string ToString()
	{
		return _value == null ? "null" : _value.ToString();
	}
}