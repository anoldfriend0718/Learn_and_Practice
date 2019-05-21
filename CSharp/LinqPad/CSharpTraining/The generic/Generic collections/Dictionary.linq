<Query Kind="Program" />

void Main()
{
	"Use dictionary".H1();
	var dic = new Dictionary<string, int>
	{
		{"a", 1},
		{"b", 2},
	};	
	dic.Add("c", 3);		
	dic["d"] = 4;
	
	dic.Dump("all data");
	
	int ret;
	if(dic.TryGetValue("d", out ret))
	{
		ret.Dump();
	}
	
	// same as
	if(dic.ContainsKey("d"))
	{
		dic["d"].Dump();
	}
	
	dic.Remove("d");
	dic.Dump("after remove");
	
	dic.Keys.Dump("all keys");
	dic.Values.Dump("all values");
}
