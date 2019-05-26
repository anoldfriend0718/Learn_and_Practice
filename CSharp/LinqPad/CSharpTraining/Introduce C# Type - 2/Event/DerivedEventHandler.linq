<Query Kind="Program" />

void Main()
{
	var mc=new MyCount();
	var ms=new MySubscribe(mc);
	mc.CountDown();
}

public interface ICount
{
	event EventHandler<CountDownEventArgs> Events; 
	void CountDown();
}

public class MyCount:ICount
{
	private int count;
	public event EventHandler<CountDownEventArgs> Events; 
	public void CountDown()
	{
		Enumerable.Range(0,5).ToList().ForEach(i=>
			{
				var eventArgs=new CountDownEventArgs();
				count=count+i;
				$"{count}".Dump();
				if(count>9)
				{
					eventArgs.Count=count;
					Events?.Invoke(this,eventArgs);	
				}
			});
	}
}

public class MySubscribe
{
	public MySubscribe(ICount counter)
	{
		counter.Events+=PrintWhenCountingDown;
	}
	
	private void PrintWhenCountingDown(object source,CountDownEventArgs e)
	{
		$"{e.Count}".Dump("Count:");
	}
}

public class CountDownEventArgs:EventArgs
{
	public int Count{get;set;}
}

// Define other methods and classes here
