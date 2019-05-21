<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	"Convert operation to Task".H1();
	
	// direct call
	"Before blocking call".H4("blue");
	ArbitraryAsyncMethod().Dump("Direct call will block current thread.");
	"After blocking call".H4("blue");
	
	// async call
	"Before async call".H4("red");
	ConvertToTask(ArbitraryAsyncMethod).Dump("Waiting for input");
	"After async call".H4("red");
}

// Define other methods and classes here

public string ArbitraryAsyncMethod()
{
	return Util.ReadLine();
}

public Task<T> ConvertToTask<T>(Func<T> target)
{
	TaskCompletionSource<T> tcs = new TaskCompletionSource<T>(); 
	
	Task.Run(() => 
		{
			tcs.SetResult(target());
		});
		
	return tcs.Task;
}