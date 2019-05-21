<Query Kind="Program" />

void Main()
{
	"Zip example".H1();
	MakePair();
	RemoveContinueDuplicateChar();
}

public void MakePair()
{
	var num = "12345";
	var str = "abcde";

	var ret = num.Zip(str, (x, y) => new { Num = x, Char = y });
	ret.Dump();
}

public void RemoveContinueDuplicateChar()
{
	var str = "11223344567888889987777665444333221111111";
	var ret = str.Zip(str.Skip(1).Append(str.Last()), (x, y) => new { First = x, Second = y })
				 .Where(pair => pair.First != pair.Second)
				 .Select(pair => pair.First)
				 .Append(str.Last())
				 .Aggregate(new StringBuilder(), (x, y) => x.Append(y))
				 .ToString()
				 .Dump();
}