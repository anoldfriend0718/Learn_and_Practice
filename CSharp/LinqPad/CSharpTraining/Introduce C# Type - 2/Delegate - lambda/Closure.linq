<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	"Watch out closure 1".H1();
	List<Func<int>> actions = new List<Func<int>>();

	int variable = 0;
	while (variable < 5)
	{
		actions.Add(() => variable * 2);
		++variable;
	}

	foreach (var act in actions)
	{
		Console.WriteLine(act.Invoke());
	}

}