<Query Kind="Program" />

void Main()
{
	"Compare different style of list file work".H1();
	// here is a sample to illustrate the functional coding style
	// can grately reduce the nest level.
	// can let programmer solve problem linearly
	var path = @"C:\TFS\Conveyance\WinchSafe\Main";	
	//FunctionalWork(path);
	ExpressionWork(path);
	//CommandWork(path);
}

public void FunctionalWork(string path)
{
	Directory.EnumerateDirectories(path, "*", SearchOption.AllDirectories)
			 .SelectMany(folder => Directory.EnumerateFiles(folder, "*.cs"))	
			 .SelectMany(file => File.ReadLines(file))
			 .Take(100)
			 .Dump();			 
}

public void ExpressionWork(string path)
{
	(
		from folder in Directory.EnumerateDirectories(path, "*", SearchOption.AllDirectories)
		from file in Directory.EnumerateFiles(folder, "*.cs")
		from line in File.ReadLines(file)
		// where !line.StartsWith("/*")
		select line
	)
	.Take(100)
	.Dump();		
}

public void CommandWork(string path)
{
	var count = 0;
	var maxCount = 100;
	var allDirs = Directory.EnumerateDirectories(path, "*", SearchOption.AllDirectories);	
	foreach(var dir in allDirs)
	{
		var allFiles = Directory.EnumerateFiles(dir, "*.cs");
		foreach(var file in allFiles)
		{
			var allLines = File.ReadLines(file);
			foreach(var line in allLines)
			{
				line.Dump();
				count++;
				if(count >= maxCount) return;				
			}
		}
	}
}