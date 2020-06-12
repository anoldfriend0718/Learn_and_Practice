<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async void Main()
{
	"Await result".H1();
	$"Thread ID before calling method:{Thread.CurrentThread.ManagedThreadId}".Dump();
	//await Print1();
	await Print2();
	$"Thread ID after calling   method:{Thread.CurrentThread.ManagedThreadId}".Dump();
	"End".H1("Red");
}

public async Task Print1()
{
	$"Thread ID before Print:{Thread.CurrentThread.ManagedThreadId}".Dump();
	var ret = Calculate(100);
	$"Thread ID after Print:{Thread.CurrentThread.ManagedThreadId}".Dump();
	"Result:".H1("Red");
	ret.Dump();
}

public async Task Print2()
{
	$"Thread ID before Print:{Thread.CurrentThread.ManagedThreadId}".Dump();
	var ret = await Calculate(100);
	$"Thread ID after Print:{Thread.CurrentThread.ManagedThreadId}".Dump();
	"Result:".H1("Red");
	ret.Dump();
}

public async Task<int> Calculate(int n)
{	
	if(n < 0) return 0;
	$"Thread ID in Calculate:{Thread.CurrentThread.ManagedThreadId}".Dump();
	return await Task.Run(() => 
	{
		$"Thread ID in Task:{Thread.CurrentThread.ManagedThreadId}".Dump();
		int sum = 0;
		for(int i = 0; i < n; i++)
		{
			sum += i;
			Thread.Sleep(10);
		}
		return sum;
	});
}