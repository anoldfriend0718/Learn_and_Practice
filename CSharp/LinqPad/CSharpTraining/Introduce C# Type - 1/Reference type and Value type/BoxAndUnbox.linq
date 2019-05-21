<Query Kind="Program" />

void Main()
{
	"Confirm boxing and unboxing by IL".H1();
	int v = 5;
	object o = v;
	v = 123;
	
	Console.WriteLine(v + ", " + (int)o);
	//Console.WriteLine(v.ToString() + ", " + o);
	
	"find box in IL window".H3("red");
}