<Query Kind="Program" />

void Main()
{
	"How extension method works".H1();
	
	"A".Repeat().Dump();
	"B".Repeat(5).Dump();
	
	// is same as
	
	MyExtension.Repeat("A").Dump();
	MyExtension.Repeat("B", 5).Dump();
}

public static class MyExtension
{
	public static string Repeat(this string @this)
	{
		return @this + @this;
	}
	
	public static string Repeat(this string @this, int count)
	{
		if(count < 2) return @this;
		return string.Join(null,Enumerable.Repeat(@this,count));
	}
}