<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Namespace>System.Collections.Concurrent</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	"Wrapped producer consumer pattern".H1();
	
	var bq = new BlockingCollection<int>();
	
	// producers
	var producerTasks = Enumerable.Range(1,3)
		.Select(i => Task.Run(() => 
		{
			var producer = new Producer<int>(bq);
			for(int j = 0; j < 5; j++)
			{
				producer.Produce(i * 100 + j);
			}			
		}));
	
	// consumers
	var consumerTasks = Enumerable.Range(1,3)
		.Select(i => Task.Run(() => 
		{
			var consumer = new Consumer<int>(bq);
			consumer.Consume(item => $"ThreadId [{Thread.CurrentThread.ManagedThreadId}]:{item}".Dump());
		})).ToList();
		
	// when all work done
	Task.WhenAll(producerTasks).ContinueWith(t => bq.CompleteAdding());
}

public class Producer<T>
{
	private readonly BlockingCollection<T> _bq;
	
	public Producer(BlockingCollection<T> bq)
	{
		_bq = bq;
	}
	
	public void Produce(T message)
	{
		_bq.Add(message);
	}
}

public class Consumer<T>
{
	private readonly BlockingCollection<T> _bq;
	
	public Consumer(BlockingCollection<T> bq)
	{
		_bq = bq;
	}	
	
	public void Consume(Action<T> action)
	{
		while(!_bq.IsCompleted)
		{				
			T item = default(T);
			try
			{
				item = _bq.Take();
			} 
			catch
			{
				// race condition, BlockingCollection here is completed.
				return;
			}							
			action(item);
		}	
	}
}