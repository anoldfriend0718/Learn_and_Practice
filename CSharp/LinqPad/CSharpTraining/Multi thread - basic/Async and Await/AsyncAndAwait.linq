<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async void Main()
{
	"Use async and await".H1();
	var dc = new DumpContainer ().Dump();
	
	 CancellationTokenSource cs = new CancellationTokenSource();
     var token = cs.Token;
	 $"Thread ID in Main Workflow:{Thread.CurrentThread.ManagedThreadId}".Dump();
	 
     var ret = Task.Run(() => 
	 {
	 	$"Thread ID in Task:{Thread.CurrentThread.ManagedThreadId}".Dump();
		var i = 0;
		while(true)
	 	//while(!token.IsCancellationRequested)
		{	
			token.ThrowIfCancellationRequested();
			dc.Content = i++;
		}
	 }, token);
	 	 	
	Thread.Sleep(100);			
	cs.Cancel();	
	
	try
	{		
		await ret;
	}
	catch(OperationCanceledException e)
	{
	    // handle error
		e.Message.Dump("Exception:");
	}
	
	ret.IsCompleted.Dump("Is Task Completed");
	ret.IsCanceled.Dump("Is Task Canceled");
	ret.IsFaulted.Dump("Is Task Error");
	ret.Status.Dump("Status");
}

// Define other methods and classes here