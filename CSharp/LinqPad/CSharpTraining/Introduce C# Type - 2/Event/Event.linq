<Query Kind="Program" />

void Main()
{
	"Understand Event".H1();
	var c = new MyClass();
	c.CountdownCompleted += () => "Completed!".Dump();
	
	for(int i = 0; i < 5; i++)
	{
		c.Add();
	}
	
	// You can't do this
	// c.CountdownCompleted.Invoke();
	
	var c2 = new MyClass2();
	c2.CountdownCompleted += () => "Completed!!!".Dump();
	
	for(int i = 0; i < 5; i++)
	{
		c2.Add();
	}
}

// simplified version
public class MyClass
{
	private int _count;
	
	public event Action CountdownCompleted;
	
	public void Add()
	{
		_count++;
		if(_count >= 5)
		{
			OnCountdownCompleted();
			_count = 0;
		}
	}
	
	protected void OnCountdownCompleted()
	{
		CountdownCompleted?.Invoke();		
	}
}

// complete version
public class MyClass2
{
	private int _count;
	
	private Action _countdownCompleted;
	
	public void Add()
	{
		_count++;
		if(_count >= 5)
		{
			OnCountdownCompleted();
			_count = 0;
		}
	}
	
	protected void OnCountdownCompleted()
	{
		_countdownCompleted?.Invoke();		
	}
	
	public event Action CountdownCompleted
	{
		add
		{
			_countdownCompleted += value;
		}
		
		remove
		{
			_countdownCompleted -= value;
		}
	}
}