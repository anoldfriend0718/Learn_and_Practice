<Query Kind="Program" />

void Main()
{
	"Good extension methods".H1();
	"In example".H2("blue");
	int condition = 0;
	if(condition == 1 || 
       condition == 6 || 
       condition == 9 || 
       condition == 11) {}	   
	// change to 
	if(condition.In(0,1,6,9,11)) {}
	
	"Between example".H2("blue");
	if (condition >= 3 && condition < 10 ) {}
	// change to 
	if (condition.Between(3,10)){}
	
	"IsNull example".H2("blue");
	int? arg = null;
	if ( arg.IsNull() ) {}
	
	"ThrowIfArgumentIsNull example".H2("blue");
	try
	{
		arg.ThrowIfArgumentIsNull(nameof(arg));
	}
	catch
	{}	
	
	"...And examples in this tutorial".H2("green");
}

public static class GoodExtension
{		
	public static bool In<T>(this T source, params T[] list)
	{
	  if(null==source) throw new ArgumentNullException("source");
	  return list.Contains(source);
	}
	
	public static bool Between<T>(this T actual, T lower, T upper) where T : IComparable<T>
    {
      return actual.CompareTo(lower) >= 0 && actual.CompareTo(upper) < 0;
    }
	
	public static bool IsNull<T>(this T arg)
	{
		return arg == null;
	}
	
    public static void ThrowIfArgumentIsNull<T>(this T obj, string parameterName)
    {
        if (obj == null) throw new ArgumentNullException(parameterName + " not allowed to be null");
    }	
}