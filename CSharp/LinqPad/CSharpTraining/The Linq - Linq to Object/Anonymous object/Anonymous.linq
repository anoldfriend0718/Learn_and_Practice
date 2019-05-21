<Query Kind="Program" />

void Main()
{
	"Anonymous type".H1();
	var data = "1,Red;2,Blue;3,Green";	
	
	var ret = data.Split(';').Select(x =>
		{
			var item = x.Split(',');
			return new {ID = item[0], Name = item[1]};
		});
	
	ret.Dump();
	
	var myobj = new {Age = 10, Location = "Beijing"};
	myobj.Age.Dump();
	myobj.Location.Dump();
	
	var myobj2 = new {Age = 10, Location = "Beijing"};	
	(myobj == myobj2).Dump("Same reference?");
	(myobj.GetHashCode() == myobj2.GetHashCode()).Dump("Same HashCode?");
	(myobj.Equals(myobj2)).Dump("Equal?");
}