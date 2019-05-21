<Query Kind="Program" />

void Main()
{
	"ManualResetEvent".H1();

	//STEP 1: Create a wait handle
	ManualResetEvent[] events = new ManualResetEvent[10];//Create a wait handle
	for (int i = 0; i < events.Length; i++)
	{
		events[i] = new ManualResetEvent(false);
		Runner r = new Runner(events[i], i);
		new Thread(r.Run).Start();
	}

	//STEP 2: Register for the events to wait for
	int index = WaitHandle.WaitAny(events); //wait here for any event and print following line.

	Console.WriteLine("***** The winner is {0} *****", index);

	events.ToList().ForEach(e => e.WaitOne());

	Console.WriteLine("All finished!");
}

class Runner
{
	static readonly object rngLock = new object();
	static Random rng = new Random();

	ManualResetEvent ev;
	int id;

	internal Runner(ManualResetEvent ev, int id)
	{
		this.ev = ev;//Wait handle associated to each object, thread in this case.
		this.id = id;
	}

	internal void Run()
	{
		//STEP 3: Do some work
		for (int i = 0; i < 2; i++)
		{
			int sleepTime;

			lock (rngLock)
			{
				sleepTime = rng.Next(2000);
			}
			Thread.Sleep(sleepTime);
			Console.WriteLine("Runner {0} at stage {1}", id, i);
		}

		//STEP 4: Im done!
		ev.Set();
	}
}