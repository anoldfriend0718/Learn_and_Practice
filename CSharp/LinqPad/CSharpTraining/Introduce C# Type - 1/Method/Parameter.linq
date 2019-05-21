<Query Kind="Program" />

void Main()
{
	"Define optional parameter and use naming parameter".H1();
	Run(1,2,"3").Dump();
	Run(1,2).Dump();
	Run(1).Dump();
	
	Run(a : 1, b: 2, c : "test").Dump();
	Run(1, c : "run").Dump();
}

public string Run(int a, int b = 1, string c = null)
{
	return $"{nameof(a)}={a};{nameof(b)}={b};{nameof(c)}={c??"null"}";
}

// Define other methods and classes here