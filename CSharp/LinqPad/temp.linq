<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Namespace>System.Collections.Concurrent</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var _workingDirectory=@"C:\local\";
	//Directory.EnumerateDirectories(_workingDirectory) .Dump()
	//.Where(x => (Path.GetFileName(x)).StartsWith("tmp")) .Dump()
	//.ToList() .Dump()
	//.ForEach(folder => Directory.Delete(folder, true));

	//Directory.EnumerateFiles(_workingDirectory) .Dump()
	//.Where(x => Path.GetFileName(x).StartsWith("tmp")) .Dump()
	//.ToList() .Dump()
	//.ForEach(File.Delete);
	try
	{
		throw new ArgumentNullException("prop1");
	}
	catch (ArgumentNullException e)
	{
		e.Message.Dump("catch");
		throw;
	}
	finally
	{
		"clean up".Dump("final");
	}


	//nameof(MyClass).Dump("MyClass Name");
	//nameof(MyClass.MyProp).Dump("MyProp Name");
	//try
	//{
	//	throw new ArgumentNullException(nameof(MyClass.MyProp));
	//}
	//catch (ArgumentNullException e)
	//{
	//	e.Message.Dump("Error Message");
	//}
	
	
	
	
	//Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Dump();
//	List<int> a=new List<int>() {0,1,0,1,0};
//	a.Dump();
//	var b=a.Where(x=>x==1).ToList();
//	b.Dump();
//
//	Enumerable.Range(0, 10).Dump();
//	(new {ID=1,Num=2}).Dump();
//	
//	Enumerable.Range(0,10)  .Dump("Origin")
//		.Where(x => x % 2 == 0) .Dump("where")
//		.OrderByDescending(x => $"V{x}") .Dump("OrderByDescending")
//		.Dump();

}


public class MyClass
{
	public string MyProp {get;set;}
}

public class Consumer<T>
{
   private T _prop;
   public Consumer(T prop)
   {
   	_prop=prop;
	Console.WriteLine($"Consume {typeof(T)}");
   }

}

public class Prop
{
}

// Define other methods and classes here