<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async void Main()
{
	"Before Calling".H1("blue");
	$"Thread ID before Calling:{Thread.CurrentThread.ManagedThreadId}".Dump();
	//MyClass.DoDelayWork(); //Remark: no await => main thread is not blocked here, A task object is returned here 
	await MyClass.DoDelayWork();
	$"Thread ID after Calling:{Thread.CurrentThread.ManagedThreadId}".Dump();
	"After Calling".H1("blue");
}

public class MyClass
{
	public static async Task DoDelayWork()
	{
		"Before Delaying".Dump();
		$"Thread ID before Delaying:{Thread.CurrentThread.ManagedThreadId}".Dump();
		await Task.Delay(1000);
		$"Thread ID After Delaying:{Thread.CurrentThread.ManagedThreadId}".Dump();
		"After Delaying".Dump();
		
	}
	
}

// Define other methods and classes here
