<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async void Main()
{
	"Start".Dump();
	await CallMyMethodAsync();
	"Done".Dump();
}

public async Task MyMethodAsync(IProgress<double> progress=null)
{
   var delay=TimeSpan.FromSeconds(1);
   await Task.Delay(delay)
             .ContinueWith(preTask=>{if(progress!=null){progress.Report(100.0);}})
			 .ContinueWith(preTask=>"MyMethodAsync Done".Dump());

}

public async Task CallMyMethodAsync()
{
	var progress=new Progress<double>();
	progress.ProgressChanged+=(sender,arg)=>{$"Progress is {arg}%".Dump();};
	await MyMethodAsync(progress);
	
}
// Define other methods and classes here
