<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	"AutoResetEvent".H1();

	var are = new AutoResetEvent(false);
	Task.Run(() =>
		{
			for (int i = 0; i < 3; i++)
			{
				Thread.Sleep(100);
				are.WaitOne();
				$"ThreadID:{Thread.CurrentThread.ManagedThreadId} Looping".Dump();
			}
		});

	Util.ReadLine();
	are.Set();
	Util.ReadLine();
	are.Set();
	Util.ReadLine();
	are.Set();
}

