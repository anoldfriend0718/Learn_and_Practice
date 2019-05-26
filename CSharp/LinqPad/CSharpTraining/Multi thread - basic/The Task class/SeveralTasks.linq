<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async void Main()
{
	"Start Several Task".H1("Red");
	$"Thread ID before calling method:{Thread.CurrentThread.ManagedThreadId}".Dump();
	var t1=MyClass.RunAsync(1);
	var t2=MyClass.RunAsync(2);
	$"Thread ID after calling method:{Thread.CurrentThread.ManagedThreadId}".Dump();
	"End Several Task".H1("Red");
	
}

public class MyClass
{
	public static async Task RunAsync(int id)
	{
		await Task.Run(()=>
		{				
			Thread.Sleep(5000);
			$"Thread ID in Task{id}:{Thread.CurrentThread.ManagedThreadId}".Dump();
			"Hello World".H2("Green");
		}
		);
	}
}

// Different background thread for different tasks to run different async methods
