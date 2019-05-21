<Query Kind="Program" />

void Main()
{
	"Watch out reference".H1();
	var data = QueryData();
	
	var ret = new List<MyType>();
	
	var temp = new MyType();
	foreach(var mytype in data)
	{
		// do something
		temp.Id = mytype.Id;
		temp.Name = mytype.Name;
		ret.Add(temp);
	}
	
	ret.Dump();
	
	"what result will be if we change the type from class to struct?".Info();
}

public List<MyType> QueryData()
{
	return new List<MyType>
	{
		new MyType{Id = 1, Name ="A"},
		new MyType{Id = 2, Name ="B"},
		new MyType{Id = 3, Name ="C"},
	};
}

// what result will be if we change the type from class to struct?
public class MyType
{
	public int Id {get;set;}
	public string Name {get;set;}
}