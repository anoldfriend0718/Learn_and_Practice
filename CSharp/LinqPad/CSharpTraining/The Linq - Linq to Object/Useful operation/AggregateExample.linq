<Query Kind="Program" />

void Main()
{
	"Aggregate example".H1();
	// simple use
	SimpleUse();
	
	// complex use
	SplitData();
	
	var strArr = Enumerable.Range(0, 10).Select(x => x.ToString());
}

public void SimpleUse()
{
	var list = Enumerable.Range(1,10);	
	// sum
	list.Aggregate((x,y) => x + y).Dump("sum");
}

delegate State State(char c);

public void SplitData()
{
	var data = "123Abc44D2345ZZZZ";
	
	State initState = null;
	State numberState = null;
	State charState = null;
	
	var retList = new List<string>();
	var sb = new StringBuilder();
	
	initState = x => 
	{
		sb.Append(x);		
		return Char.IsDigit(x) ? numberState : charState;		
	};
	
	numberState = x =>
	{
		if(Char.IsDigit(x))
		{
			sb.Append(x);
			return numberState;
		}
		
		retList.Add(sb.ToString());
		sb.Clear();
		sb.Append(x);
		return charState;
	};
	
	charState = x =>
	{
		if(!Char.IsDigit(x))
		{
			sb.Append(x);
			return charState;
		}
		
		retList.Add(sb.ToString());
		sb.Clear();
		sb.Append(x);
		return numberState;
	};
	
	data.Aggregate(initState,(state,c) => state(c));
	
	if(sb.Length > 0)
	{
		retList.Add(sb.ToString());
	}
	
	retList.Dump();
}