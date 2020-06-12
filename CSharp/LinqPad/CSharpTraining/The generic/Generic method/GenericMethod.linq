<Query Kind="Program" />

void Main()
{
	"Generic method".H1();
	int a = 1;
	int b = 2;
	Util.Swap(ref a, ref b);
	$"a={a};b={b}".Dump();
	
	string s1 ="a";
	string s2 = "b";
	Util.Swap(ref s1, ref s2);
	$"s1={s1};s2={s2}".Dump();
}

public static class Util
{
	public static void Swap<T>(ref T p1, ref T p2)
	{
		T temp = p1;
		p1 = p2;
		p2 = temp;
	}
}