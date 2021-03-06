<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	"Cancel Task".H1();
	var dc = new DumpContainer ().Dump();
	
	 var cs = new CancellationTokenSource();
     var token = cs.Token;
	 $"Thread ID in calling method:{Thread.CurrentThread.ManagedThreadId}".Dump();
     var ret = Task.Run(() => 
	 {
	 	$"Thread ID in Task:{Thread.CurrentThread.ManagedThreadId}".Dump();
		var i = 0;
	 	while(true)
		{	
			token.ThrowIfCancellationRequested();
			dc.Content = i++;
		}
	 }, token);
	 	 	
	Thread.Sleep(10);			
	cs.Cancel();	
	
	try
	{
		ret.Wait();
	}
	catch(AggregateException ae)
	{
		foreach(var innerException in ae.Flatten().InnerExceptions)
	    {
	        // handle error
			innerException.GetType().Name.Dump("Exception Type:");
			innerException.Message.Dump("Exception:");
	    }
	}
	
	$"Thread ID in calling method:{Thread.CurrentThread.ManagedThreadId}".Dump();
	ret.IsCompleted.Dump("Is Task Completed");
	ret.IsCanceled.Dump("Is Task Canceled");
	ret.IsFaulted.Dump("Is Task Error");
	ret.Status.Dump("Status");
}

// Define other methods and classes here