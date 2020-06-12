<Query Kind="Program" />

void Main()
{
	"Use Thread class".H1();
	
	"Use thread when you want:".H2("blue");
	"1. Use front thread.".Info();
	"2. Control the thread instance yourself.".Info();
	
	Thread thread = new Thread(() => 
	{
		Thread.Sleep(1000);		
		$"Long running task running on : {Thread.CurrentThread.ManagedThreadId}".Dump();
	});
		
	$"Main thread running on : {Thread.CurrentThread.ManagedThreadId}".Dump();
	thread.IsBackground.Dump();
	thread.Start();
}