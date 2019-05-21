<Query Kind="Program" />

void Main()
{
	"List operations".H1();
	var list = new List<string>
	{"3","2","1","4","5"};
	
	list.Add("6");
	
	list.Dump("all data");
	list.IndexOf("1").Dump("1 in index");
	list.Sort();
	list.Dump("sorted data");
	list.IndexOf("1").Dump("1 in index");
	list.BinarySearch("2").Dump("2 in index");
	
	list.RemoveAt(0);
	list.Remove("6");
	list.Dump("remain data");
	list[0].Dump("first data");
	
	list.AsReadOnly().Dump("ReadOnly list");
}
