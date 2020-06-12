<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	"Use ThreadLocal".H1();
	
	"Not Thread Safe".H2("blue");
	
	var nts = new NotUseThreadLocal();
	var ntsTasks = Enumerable.Range(1,2).Select(i => Task.Run(() => 
		{
			nts.Run();
		}));
	
	Task.WaitAll(ntsTasks.ToArray());
	nts._tl.Dump("After operation of not thread safe.");
	
	"Thread Safe".H2("blue");
	
	var ts = new UseThreadLocal();
	var tsTasks = Enumerable.Range(1,2).Select(i => Task.Run(() => 
		{
			ts.Run();
		}));
		
	Task.WaitAll(tsTasks.ToArray());
	ts._tl.Value.Dump("After operation of thread safe.");	
	
	"Do not use [ThreadStatic] attribute to do same work".H2("red");
}

public class UseThreadLocal
{
	public ThreadLocal<int> _tl = new ThreadLocal<int>(() => 0);
	
	public void Run()
	{
		for (int i = 1 ; i <= 100 ; i++)
		{
			Thread.Sleep(1);
			_tl.Value +=i;
		}
		
		_tl.Value.Dump($"In Thread {Thread.CurrentThread.ManagedThreadId}");
	}
}

public class NotUseThreadLocal
{
	public int _tl = 0;
	
	public void Run()
	{
		for (int i = 1 ; i <= 100 ; i++)
		{
			Thread.Sleep(1);
			_tl +=i;
		}
		
		_tl.Dump($"In Thread {Thread.CurrentThread.ManagedThreadId}");
	}
}