<Query Kind="Program" />

void Main()
{
	"How linq works".H1();
	var obj = new MyClass<int>(1);
	
	var ret1 = obj.Select( x => x + 8);	   			
		ret1.Dump("Select method call");	
	
	var ret2 = obj.Select( x => x)
	   			 .SelectMany( x => new MyClass<string>("2"), 
				 			  (x,y) => x + double.Parse(y));
		ret2.Dump("SelectMany method call");
		
	// can also use linq expression
	
	var ret3 = from d in new MyClass<int>(1)
			   select d + 8;
	ret3.Dump("Select expression");
			   
	var ret4 = from x in new MyClass<int>(1)
			   from y in new MyClass<string>("2")
			   select x + double.Parse(y);
	ret4.Dump("SelectMany expression");
	   
	// more example, see Functional folder

}

// Define a simple container to hold the value
public class MyClass<T>
{
	private T _value;
	
	public T Value 
	{ 
		get { return _value; }
	}
	
	public MyClass(T value)
	{
		_value = value;
	}
	
	public override string ToString()
	{
		return _value?.ToString();
	}
}

public static class MyClassExtension
{
	public static MyClass<TResult> Select<T, TResult>(this MyClass<T> @this, Func<T, TResult> map)
	{
		return new MyClass<TResult>(map(@this.Value));
	}
	
	public static MyClass<TResult> SelectMany<T, U, TResult>(
		this MyClass<T> @this, 
		Func<T, MyClass<U>> map, 
		Func<T, U, TResult> resultSelector)
	{
		return new MyClass<TResult>(resultSelector(@this.Value, map(@this.Value).Value));
	}	
}