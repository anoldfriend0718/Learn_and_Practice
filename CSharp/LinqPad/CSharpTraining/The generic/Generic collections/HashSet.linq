<Query Kind="Program" />

void Main()
{
	"Set operations".H1();
	var set = new HashSet<int>
	{1,2,3,4,5};
	
	set.Add(6);
	set.Add(5);
	
	set.Dump("original");
	
	var list = new List<int>{4,5,6,7};
	
	set.UnionWith(list);
	set.Dump("Union");
	set.ExceptWith(list);
	set.Dump("Except");
	set.IntersectWith(new List<int>{1,2});
	set.Dump("Intersect");
}
