<Query Kind="Program" />

void Main()
{
	"Enum".H1();
	Color.Black.ToString().Dump();
	Enum.GetUnderlyingType(typeof(Color)).Name.Dump("underlying type:");
	((Color[])Enum.GetValues(typeof(Color))).Select(x => x.ToString()).Dump();
	((Color[])Enum.GetValues(typeof(Color))).Select(x => x.ToString("D")).Dump("Values:");
	Enum.GetNames(typeof(Color)).Dump("Names:");
	
	Enum.Parse(typeof(Color), "Red").Dump("parse:");
	
	Enum.IsDefined(typeof(Color), 1).Dump("confirm 1 is defined");
	Enum.IsDefined(typeof(Color), "Green").Dump("confirm Green is defined");
	var value = (Color)1;
	value.Dump("convert from value:");
}

// Define other methods and classes here
public enum Color
{
	Red,
	Green,
	Black
}