<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async void Main()
{
	"Await result".H1();
	await Print();
	"End".Dump();
}

public async Task Print()
{
	int ret = await Calculate(10);
	ret.Dump("Result:");
}

public async Task<int> Calculate(int n)
{	
	if(n < 0) return 0;
	
	return await Task.Run(() => 
	{
		int sum = 0;
		for(int i = 0; i < n; i++)
		{
			sum += i;
			Thread.Sleep(10);
		}
		return sum;
	});
}