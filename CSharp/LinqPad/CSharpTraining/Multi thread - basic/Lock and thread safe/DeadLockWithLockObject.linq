<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	"Dead lock with lock object".H1();

	var t1 = new Thread(Method1);
	var t2 = new Thread(Method2);
	t1.Start();
	t2.Start();
}

public void Method1()
{
	lock (typeof(int))
	{
		Thread.Sleep(1000);
		"Befor enter float lock".Dump("Method1");
		lock (typeof(float))
		{
			"Thread 1 got both locks".Dump("Method1");
		}
	}
}

public void Method2()
{
	lock (typeof(float))
	{
		Thread.Sleep(1000);
		"Befor enter int lock".Dump("Method2");
		lock (typeof(int))
		{
			"Thread 1 got both locks".Dump("Method2");
		}
	}
}
