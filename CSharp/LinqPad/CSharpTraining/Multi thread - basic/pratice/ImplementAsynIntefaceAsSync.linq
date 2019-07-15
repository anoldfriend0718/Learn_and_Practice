<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async void Main()
{
	var mc=new MySynchronousImplementaion();
	var result=await mc.GetResult();
	result.Dump("Result");
	
	var mc1=new MyClass<int>();
	var result1=await mc1.ConvertToTask(mc1.GetResult,13);
	result1.Dump("Result1");
	
}


public interface IMyAsyncInterface
{
	Task<int> GetResult();
}

public class MySynchronousImplementaion:IMyAsyncInterface
{
	public Task<int> GetResult()
	{
		return Task.FromResult(13);
	}	
}

public class MyClass<T>
{
	public T GetResult(T result)
	{
		return result;
	}
	
	public Task<T> ConvertToTask(Func<T,T> syncMethod,T result)
	{
		var tcs=new TaskCompletionSource<T>();
	    Task.Run(()=>
		{
			try
			{
				tcs.SetResult(syncMethod(result));
			}
			catch(Exception e)
			{
				tcs.SetException(e);
			}
		});
		return tcs.Task;
		
	}
}



//public Task<T> ConvertToTask<T>(Func<T> target)
//{
//	TaskCompletionSource<T> tcs = new TaskCompletionSource<T>(); 
//	
//	Task.Run(() => 
//		{
//			tcs.SetResult(target());
//		});
//		
//	return tcs.Task;
//}
