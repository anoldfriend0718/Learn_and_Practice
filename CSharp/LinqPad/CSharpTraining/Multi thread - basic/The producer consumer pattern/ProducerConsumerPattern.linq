<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Namespace>System.Collections.Concurrent</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	"Raw producer consumer pattern".H1();
	
	BlockingCollection<int> bq = new BlockingCollection<int>();
//	Enumerable.Range(1,10).ToList().ForEach(i=>bq.Add(i));
//	bq.CompleteAdding();
	var tasks = Enumerable.Range(1,10).Select(i => Task.Run(() => bq.Add(i)));
	
	Task.WhenAll(tasks).ContinueWith(_ => bq.CompleteAdding());
			
	Enumerable.Range(1,3).ToList().ForEach(i => 
	{
		Task.Run(()=>{
		
			while(!bq.IsCompleted)
			{
				Thread.Sleep(100);
				int? item = null;
				try
				{
					item = bq.Take();
				} 
				catch
				{}			
				
				if(item != null)
				{
					$"ThreadId [{Thread.CurrentThread.ManagedThreadId}]:{item}".Dump();
				}
			}		
		});
	});
}

// Define other methods and classes here