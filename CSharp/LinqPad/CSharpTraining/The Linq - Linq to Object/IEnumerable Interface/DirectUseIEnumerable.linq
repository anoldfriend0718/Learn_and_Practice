<Query Kind="Program" />

void Main()
{
	"Use IEnumerable directly".H1();
	var data = new List<int>{1,2,3,4,5};
	
	// same as foreach
	using(var enumerator = data.GetEnumerator())
	{
		int currentItem;
		while (enumerator.MoveNext())
		{
			currentItem = enumerator.Current;
			currentItem.Dump();
		}
	}
}