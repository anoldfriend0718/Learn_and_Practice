<Query Kind="Program" />

void Main()
{
	//var casename = "test";
	//var ibeJsonPath = @"C:\local\Temp\test.json";
	//var workingDir = @"C:\local\Temp\";
	////CreateCommandlineOptions(casename,ibeJsonPath,workingDir).Dump();
	//Directory.EnumerateDirectories(workingDir) .Dump()
	//    .Concat(Directory.EnumerateFiles(workingDir)) .Dump()
	//	.Select(x=>Path.GetFileName(x)).Dump();

	//Directory.EnumerateFiles(workingDir).Dump()
	//.Select(x => Path.GetFileName(x)).Dump();
	double? a=null;
	a.Value.Dump();

}



string CreateCommandlineOptions(string caseName, string ibeJsonPath, string workingDir)
{
	var stringBuilder = new StringBuilder();
	var commandlineOptions = stringBuilder.Append(ibeJsonPath)
		.Append($" -verbose=0 -Ccall -autoclean=0 -casename={caseName}")
		.Append($" > {workingDir}\\{caseName}.out_err 2>&1 ")
		.Append($" -workingdir={workingDir}")
		.ToString();
	return commandlineOptions;
}