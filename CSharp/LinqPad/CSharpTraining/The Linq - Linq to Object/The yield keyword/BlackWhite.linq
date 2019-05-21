<Query Kind="Program" />

void Main()
{
    
	"MyClass1".H2("Blue");
	var mc1=new MyClass1();
	foreach(var element in mc1)
	{
		element.Dump();
	}
	
	"MyClass2".H2("Blue");
	var mc2=new MyClass2();
	foreach(var element in mc2)
	{
		element.Dump();
	}
}

public class MyClass1
{
	public IEnumerator<string> GetEnumerator()
	{
		return BlackWhite();
	}
	public IEnumerator<string> BlackWhite()
	{
		yield return "black";
		yield return "gray";
		yield return "white";
	
	}
}

public class MyClass2
{
	public IEnumerator<string> GetEnumerator()
	{
		return BlackWhite().GetEnumerator();
	}
	public IEnumerable<string> BlackWhite()
	{
		yield return "black";
		yield return "gray";
		yield return "white";	
	}	
}


// Define other methods and classes here
