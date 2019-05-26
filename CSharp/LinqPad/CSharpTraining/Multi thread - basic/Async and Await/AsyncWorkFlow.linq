<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async void Main()
{
	"Start".H1("red");
	
	$"{Thread.CurrentThread.ManagedThreadId}".Dump("Thread ID before calling method:");
	Task<int> ret=DoAsyncStuff.GetSum(1,2);
	ret.Dump("Awaiting Result:");
	$"{Thread.CurrentThread.ManagedThreadId}".Dump("Thread ID after calling method:");
	
	DoAsyncStuff.Print();
	ret.Result.Dump("Blocking Result:");
	"End".H1("red");
}

public class DoAsyncStuff
{
	public static async Task<int> GetSum(int a, int b)
	{
		$"{Thread.CurrentThread.ManagedThreadId}".Dump("Thread ID before Task method:");
		return await Task.Run(
		()=>
		{
			$"{Thread.CurrentThread.ManagedThreadId}".Dump("Thread ID in Task method:");
			var c=a+b;
			Thread.Sleep(1000);
			return c;
		}
		);
	}
	
	public static void Print()
	{
		"Calculating".H2("blue");
	}
}

// Define other methods and classes here
