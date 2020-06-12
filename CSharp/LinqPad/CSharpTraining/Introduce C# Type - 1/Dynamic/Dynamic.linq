<Query Kind="Program" />

void Main()
{
	"Dynamic type".H1();
	var ret = Plus(1,1);
	((object)ret).Dump();
	
	ret = Plus(1.1,1.2);
	((object)ret).Dump();
	
	ret = Plus("a","b");
	((object)ret).Dump();	
	
}

// Define other methods and classes here
public dynamic Plus(dynamic a, dynamic b)
{
	return a + b;
}