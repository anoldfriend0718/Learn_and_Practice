<Query Kind="Program" />

void Main()
{
	"Take and Skip".H1();

	Enumerable.Range(0, 100)
		.Skip(50)
		.Take(10)
		.Dump("Skip and take");

	Enumerable.Range(0, 100)
		.SkipWhile(x => x < 50)
		.TakeWhile(x => x < 60)
		.Dump("Skip while and take while");
}

// Define other methods and classes here
