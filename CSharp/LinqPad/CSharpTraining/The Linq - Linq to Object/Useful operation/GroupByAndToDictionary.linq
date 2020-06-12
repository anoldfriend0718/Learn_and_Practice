<Query Kind="Program" />

void Main()
{
	"GroupBy and ToDictionary".H1();
	var data = Enumerable.Range(1, 10);

	var grouped1 = data.GroupBy(num => num % 2 == 0).Dump("Group by key only");

	var dic1 = grouped1.ToDictionary(x => x.Key ? "even" : "odd"
									, x => string.Join(",", x)).Dump("convert to Dictionary");

	var grouped2 = data.GroupBy(num => num % 2 == 0 ? "even" : "odd"
						, (key, numsIngroup) => numsIngroup.Select(num => $"{key} - {num}"))
						.Dump("Group by key use result selector");

	var grouped3 = data.GroupBy(num => num % 2 == 0 ? "even" : "odd"
						, num => $"'{num}'"
						, (key, numIngroup) => $"{key}:{string.Join(",", numIngroup)}")
						.Dump("Group by key use element selector and result selector");

	var expression = from num in data
					 group $"'{num}'" by num % 2 == 0 ? "even" : "odd" into g
					 select $"{g.Key}:{string.Join(",", g)}";

	expression.Dump("Use expression");
}

// Define other methods and classes here