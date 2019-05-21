<Query Kind="Program" />

//???why use indexer

void Main()
{
	"Define properties and Indexer".H1();
	var instance = new MyClass();
	instance.Age.Dump("Age:");
	instance.Name.Dump("Name:");

	instance[1] = "test indexer";
	instance[1].Dump();
}

public class MyClass
{
	// style 1 use field
	private int _age = 1;
	public int Age
	{
		get { return _age; }
		private set { _age = value; }
	}

	// style 2 use hidden field
	public string Name { get; private set; } = "Default Name";

	// indexer
	public string this[int index]
	{
		get { return $"indexer get : {index}".ToString(); }
		set { $"indexer set : {index} = {value}".Dump(); }
	}
}