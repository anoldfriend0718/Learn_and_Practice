<Query Kind="Program" />

void Main()
{
	"Compare lock".H1();
	new List<LockDescription>
	{
		new LockDescription(){LockType = "lock (Monitor.Enter / Monitor.Exit)", CrossProcess = "No", Overhead = "20ns"},
		new LockDescription(){LockType = "Mutex", CrossProcess = "Yes", Overhead = "1000ns"},
		new LockDescription(){LockType = "SemaphoreSlim", CrossProcess = "No", Overhead = "200ns"},
		new LockDescription(){LockType = "Semaphore", CrossProcess = "Yes", Overhead = "1000ns"},
		new LockDescription(){LockType = "ReaderWriterLockSlim", CrossProcess = "No", Overhead = "40ns"},
		new LockDescription(){LockType = "ReaderWriterLock", CrossProcess = "No", Overhead = "100ns"},
		new LockDescription(){LockType = "ManualResetEvent", CrossProcess = "No", Overhead = "-"},
		new LockDescription(){LockType = "AutoResetEvent", CrossProcess = "No", Overhead = "-"},
	}.Dump();
}

public class ThreadSafeWithLock
{
    static readonly object _locker = new object();
    static int _val1 = 1, _val2 = 1;
 
    static void Go()
    {
      lock (_locker)
      {
        if (_val2 != 0) Console.WriteLine (_val1 / _val2);
        _val2 = 0;
      }
    }
  
  
	public void LockLooksLikeThis()
	{
		bool lockTaken = false;
		try
		{
		  Monitor.Enter (_locker, ref lockTaken);
		  // Do your stuff...
		}
		finally { if (lockTaken) Monitor.Exit (_locker); }
	}  
}

public class LockDescription
{
	public string LockType{get;set;}
	public string CrossProcess{get;set;}
	public string Overhead{get;set;}
}