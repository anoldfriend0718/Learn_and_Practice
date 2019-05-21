<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	"Watch out closure 2".H1();
	//Test1();
	//Test2();
	//Test3();
	Test4();
}

void Test1()
{
	for (var i = 0; i < 5; ++i)
	{
		Task.Factory.StartNew(() =>
		{
			i.Dump();
		});
	}
}

void Test2()
{
	for (var i = 0; i < 5; ++i)
	{
		Task.Factory.StartNew(() =>
		{
			var ii = i;
			ii.Dump();
		});
	}
}

void Test3()
{
	for (var i = 0; i < 5; ++i)
	{
		var ii = i;
		Task.Factory.StartNew(() =>
		{
			ii.Dump();
		});
	}
}

void Test4()
{
	for (var i = 0; i < 5; ++i)
	{
		Task.Factory.StartNew(ii =>
		{
			ii.Dump();
		}, i);
	}
}