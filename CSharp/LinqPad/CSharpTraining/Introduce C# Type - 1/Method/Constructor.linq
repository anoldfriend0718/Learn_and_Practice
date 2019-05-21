<Query Kind="Program" />

void Main()
{
	"Constructor".H1();
	"consider when to use constructor to fill fields and when use property to fill fields".H3("red");
}

public class MyClass1
{
	private int _x = 10;
}

// is same as
public class MyClass2
{
	private int _x;
	public MyClass2():base()
	{
		_x = 10;
	}
}

// use this to call another constructor
public class MyClass3
{
	private int _x;
	
	public MyClass3():this(10)
	{}
	
	public MyClass3(int x)
	{
		_x = x;
	}
}

// struct can not have default constructor
public struct MyStruct
{
	// private int _x = 5;
	
	// public MyStruct() { _x = 5;}
}