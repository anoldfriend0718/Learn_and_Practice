<Query Kind="Program" />

void Main()
{
	"Let example".H1();
	List<string> files = new List<string>()
		{
			@"c:\abc\pqr\tmp\sample\b.txt",
			@"c:\abc\pqr\tmp\new2\c1.txt",
			@"c:\abc\pqr\tmp\b2.txt",
			@"c:\abc\pqr\tmp\b3.txt",
			@"c:\abc\p"
		};

	var matchingChars =
		from len in Enumerable.Range(0, files.Min(s => s.Length) + 1).Reverse()
		let possibleMatch = files.First().Substring(0, len)
		where files.All(f => f.StartsWith(possibleMatch))
		select possibleMatch;

	matchingChars.Dump("ret:");

	matchingChars.First().Dump("Result:");

	Enumerable.Range(0, files.Min(s => s.Length) + 1).Reverse()
			  .Select(len => new { PossibleMatch = files.First().Substring(0, len), Len = len })
			  .Where(x => files.All(f => f.StartsWith(x.PossibleMatch)))
			  .Select(x => x.PossibleMatch)
			  .First()
			  .Dump("Function call:");

}

// Define other methods and classes here