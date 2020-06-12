<Query Kind="Program" />

void Main()
{
	"Nullable".H1();
	Nullable<int> a = null;
	//a.GetType().Dump("nullable type");
	
	int? b = null;
	
	// box without value
	object o = b;
	(b == null).Dump("b Is Null?");
	
	// box with value
	b = 5;
	o = b;
	
	b.GetType().Dump("nullable type via GetType Method");
	o.GetType().Dump("nullable type via boxing type");
	typeof(int?).Dump("nullable type via typeof operator");
	
	// compare
	"All comparison will be false".H3("red");
	(-1 < a).Dump("compare with value");
	
	"All computation will be null".H3("red");
	// compute
	(a++).Dump("compute");
	
	"Default values".H3();
	// default value of nullable
	default(int).Dump("default value of value type");
	default(int?).Dump("default value of nullable type");
	typeof(int?).IsValueType.Dump("nullable is value type?");
	
	// care the cast rule
	double c = (double)(int)(object)(int?)5;
}

// Define other methods and classes here