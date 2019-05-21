<Query Kind="Program" />

void Main()
{
	"Random string".H1();

	RandomString("ABCDE").Dump("Shuffle string");

	RandomLengthString(16).Dump("Random string");
}

public string RandomString(string seed)
{
	if (seed == null || seed.Length < 2) return seed;

	var chars = seed.OrderBy(c => Guid.NewGuid()).ToArray();
	return new string(chars);
}

public string RandomLengthString(int length)
{
	if(length < 1) return string.Empty;
	
	return new string(Enumerable.Repeat(
							Enumerable.Range(65, 26).Select(x => (char)x)
							, length / 26 + 1)
					 .SelectMany(cSeq => cSeq)
					 .OrderBy(c => Guid.NewGuid())
					 .Take(length)
					 .ToArray());
}