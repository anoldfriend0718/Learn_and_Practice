<Query Kind="Program" />

void Main()
{
	"Define delegate with different style".H1();
	// style1
	MyClass c = new MyClass();
	
	// use non static method
	MyDelegate d = new MyDelegate(c.ToStr);
	d.Invoke(1).Dump("1-1");
	d(1).Dump("1-2");
	
	// use static method
	d = new MyDelegate(MyClass.ToString);
	d(1).Dump("1-3");
	
	// style 2
	d = c.ToStr;
	d(1).Dump("2-1");
	
	d = MyClass.ToString;
	d(1).Dump("2-2");
	
	// style 3	
	d = delegate(int input){ return input.ToString();};
	d(1).Dump("3-1");
	
	// style 4
	d = x => x.ToString();
	d(1).Dump("3-2");	
}

// declare delegate
public delegate string MyDelegate(int input);

public class MyClass
{
	public static string ToString(int input)
	{
		return input.ToString();
	}
	
	public string ToStr(int input)
	{
		return input.ToString();
	}
}