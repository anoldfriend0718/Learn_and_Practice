<Query Kind="Program" />

void Main()
{
	"Generic constraint".H1();
}

public class MyClass<T> where T : class, IEnumerable<T>, IEnumerator<T>, IDisposable
{
	private T _value;

	public IEnumerator<T> Generate()
	{
		using(_value)
		{
			return _value.GetEnumerator();
		}
	}

	public U Create<U>(U u) where U : T, new()
	{
		return new U();
	}
	
	public int Compare<V>(V v1, V v2) where V : struct, IComparable<V>
	{
		return v1.CompareTo(v2); 
	}
}