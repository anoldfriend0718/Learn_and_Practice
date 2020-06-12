<Query Kind="Program" />

void Main()
{
	"Delegate chain".H1();
	Action action = null;
	Container c = new Container();
	action += c.Run1;
	action += c.Run2;	
	action();
	action -= c.Run1;
	//action -= c.Run2;
	
	(action == null).Dump("confirm null");
	
	action?.Invoke();
}

public class Container
{
	public void Run1()
	{
		"Run1".Dump();
	}
	
	public void Run2()
	{
		"Run2".Dump();
	}
}