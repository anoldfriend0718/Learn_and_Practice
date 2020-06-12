<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async void Main()
{
	$"{Thread.CurrentThread.ManagedThreadId}".Dump("Thread ID before calling method");
	await MyClass.DoAsyncWork();
}

public class MyClass
{
	public static async Task DoAsyncWork()
	{
		await Task.Run(()=>
		{
			$"{Thread.CurrentThread.ManagedThreadId}".Dump("Thread ID in First Task");
			"Frist Task: 5".H1("Red");
		});
		
		$"{Thread.CurrentThread.ManagedThreadId}".Dump("Thread ID after First Task:");
		
		$"Second Task:{await Task.Run(()=>{$"{Thread.CurrentThread.ManagedThreadId}".Dump("Thread ID in Second Task");return 6;})}".H1("Blue");
		$"{Thread.CurrentThread.ManagedThreadId}".Dump("Thread ID after Second Task:");
		
		
		await Task.Run(()=>
		{
			$"{Thread.CurrentThread.ManagedThreadId}".Dump("Thread ID in Third Task");
			"Third Task: 7".H1("Yellow");
		});
		
		$"{Thread.CurrentThread.ManagedThreadId}".Dump("Thread ID after Third Task:");
		
	}
}

// Remark: the background thread keep the same in the single async method