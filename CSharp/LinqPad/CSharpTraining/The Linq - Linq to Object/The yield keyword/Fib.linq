<Query Kind="Program" />

void Main()
{
	"Yield in Fib".H1();
	var datas = G().Take(100);
	foreach(var data in datas)
	{
		data.Dump();
	}
}

IEnumerable<decimal> G()
{	
	decimal current = 1;
	decimal next = 1;
	decimal ret = 0;
	try
	{	
		yield return current;
		yield return next;
		while(true)
		{
			ret = current + next;
			yield return ret;
			current = next;
			next = ret;
		}
	}
	finally
	{
		"Break!".Dump();
	}
}