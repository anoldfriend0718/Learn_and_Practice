<Query Kind="Program" />

void Main()
{
	"Define class".H1();
	"Access modifiers".H2();
	"public - anyone can see".H3("blue");
	"internal - same assembly can see".H3("blue");
	"protected - child can see".H3("blue");
	"private - only self can see".H3("blue");
	
	"internal protected - same assembly or child can see".H3("green");
	"private protected - same assembly child only C#7 only".H3("green");
}

// other modifiers: abstract, sealed, virtual(method), override(method), new(method)
public class MyClass
{
	// const
	public const int a = 1;
	
	// readonly
	private readonly int b;
	
	// static
	private static readonly int c;
	
	// type constructor
	static MyClass()
	{
		c = 1;
	}
	
	// constructor
	public MyClass()
	{
		b = 1;
		// c = 1;
	}
	
	// method
	public void MyMethod()
	{
		// b = 1;
		MyInnerClass m = new MyInnerClass();		
		// m.innerField = 2;
		
		// MyUtil util = new MyUtil();
	}
	
	// inner type
	private class MyInnerClass
	{
		private int innerField;
	}	
	
	private struct MyStruct{};
	
	private delegate void MyInnerDelegate();
	
	private enum MyEnum {};
	
	private interface MyInterface{};		
}


// static class
public static class MyUtil
{
	// can define static constructor
	static MyUtil()
	{		
	}
	
	// can define static method
	public static void Run() {}
	
	// can not define instance method
	// public void Invoke() {}
}