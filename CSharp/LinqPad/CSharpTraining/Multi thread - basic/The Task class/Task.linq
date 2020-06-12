<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	"Use Task class".H1();
	$"Thread Id in main control workflow:{Thread.CurrentThread.ManagedThreadId}".Dump();
	Task.Run(() => $"This will use thread pool thread to do work: {Thread.CurrentThread.ManagedThreadId}".Dump());
		
		
	Task.Factory.StartNew(
		() => $"This will use new thread to do work: {Thread.CurrentThread.ManagedThreadId}".Dump(), 
		TaskCreationOptions.LongRunning);	
		
		
	Task.Run(() => "Step 1".Dump())
		.ContinueWith(preTask => "Step 2".Dump())
		.ContinueWith(preTask => "Step 3".Dump());
}

// Define other methods and classes here