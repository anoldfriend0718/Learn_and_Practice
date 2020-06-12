<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationCore.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
</Query>

void Main()
{
	"C# Versions and Features.html".HTML();
}

public static class Extensions
{
	// show row html in the html result page
	public static void HTML (this string path, bool useQueryPath = true)
	{
		var queryPath = useQueryPath 
			? Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath), path)
			: path;
				
		var toDump = $"File '{queryPath}' not exist.";
		
		if(!File.Exists(queryPath))
		{
			toDump.Dump("Warning:");
			return;
		}		
		
		toDump = File.ReadAllText(queryPath);
		Util.RawHtml(toDump).Dump();	    
	}
}