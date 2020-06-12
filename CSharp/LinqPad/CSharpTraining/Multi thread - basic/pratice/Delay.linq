<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async void Main()
{
	var mc=new MyClass<int>();
	await MyClass<int>.DelayResult(1,TimeSpan.FromSeconds(1));
	"End".H1("red");
	
}

public class MyClass<T>
{
	public static async Task<T> DelayResult(T result,TimeSpan delay)
	{
		await Task.Delay(delay).ContinueWith(_=>"Result response is deplaying".Dump());
		return result;
	}
}

// Define other methods and classes here
