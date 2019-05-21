<Query Kind="Program" />

void Main()
{
	"Encapsulation".Dump();

	MyClass obj = new MyClass();
	obj.PublicField = 1;
	obj.PublicPropertyEncapsulatePrivateField = 2;
	obj.Dump();
}

public class MyClass
{
	public int PublicField;

	private int _privateField;

	public int PublicPropertyEncapsulatePrivateField
	{
		get
		{
			"you can add code here".Dump("In get method");
			return _privateField;
		}
		set
		{
			"you can add code here".Dump("In set method");
			_privateField = value;
		}
	}
}


