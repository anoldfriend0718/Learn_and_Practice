<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Namespace>System.Collections.Concurrent</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var bq=new BlockingCollection<int>();
	
	var producerTasks=Enumerable.Range(1,3)
		.Select(i=>Task.Run(()=>
		 	{
				var producer=new Producer<int>(bq);
				for(int j = 0; j < 5; j++)
				{
					producer.Produce(10*i+j);
				}
			}));
	var consumerTasks=Enumerable.Range(1,3)
		.Select(i=>Task.Run(()=>
			{
				Action<int> action=item=>$"ThreadId[{Thread.CurrentThread.ManagedThreadId}]:{item}:".Dump();
				var consumer=new Consumer<int>(bq);
				consumer.Consume(action);
			})).ToList();
	Task.WhenAll(producerTasks).ContinueWith(t => bq.CompleteAdding());
}

public class Producer<T>
{
	private readonly BlockingCollection<T> _bq;
	public Producer(BlockingCollection<T> bq)
	{
		_bq=bq;
	}
	public void Produce(T msg)
	{
		_bq.Add(msg);
	}
}

public class Consumer<T>
{
	private readonly BlockingCollection<T> _bq;
	public Consumer(BlockingCollection<T> bq)
	{
		_bq=bq;
	}
	public void Consume(Action<T> action)
	{
		
		while(!_bq.IsCompleted)
		{
			T item=_bq.Take();	
			action(item);
		}
		
	}
}
// Define other methods and classes here