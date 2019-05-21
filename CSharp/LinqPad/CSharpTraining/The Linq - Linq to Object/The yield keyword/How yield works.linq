<Query Kind="Program" />

void Main()
{
	"How yield works".H1();
	IEnumerable<int> iterable = CreateEnumerable();
	IEnumerator<int> iterator = iterable.GetEnumerator();

	"Starting to iterate".H4("blue");
	while (true)
	{
		"Calling MoveNext()...".H4("blue");
		bool result = iterator.MoveNext();
		$"... MoveNext result={result}".H4("blue");
		if (!result)
		{
			break;
		}
		"Fetching Current...".H4("blue");
		$"... Current result={iterator.Current}".H4("blue");
	}
}

static readonly string Padding = new string(' ', 30);

static IEnumerable<int> CreateEnumerable()
{
	"Start of CreateEnumerable()".Padding().Dump();

	for (int i = 0; i < 3; i++)
	{
		$"About to yield {i}".Padding().Dump();
		yield return i;
		$"After yield".Padding().Dump();
	}

	$"Yielding final value".Padding().Dump();
	yield return -1;

	$"End of GetEnumerator()".Padding().Dump();
}

public static class MyExtension
{
	public static string Padding(this string @this, int num = 30)
	{
		return new string(' ', 30) + @this;
	}
}

//Remark:
//You use a yield return statement to return each element one at a time.
//
//You consume an iterator method by using a foreach statement or LINQ query. 
//Each iteration of the foreach loop calls the iterator method. 
//When a yield return statement is reached in the iterator method, expression is returned, and the current location in code is retained.
//Execution is restarted from that location the next time that the iterator function is called.
//You can use a yield break statement to end the iteration.