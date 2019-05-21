<Query Kind="Program" />

void Main()
{
	"Convariance and contravariance - Generic".H1();
	Func<string> e1 = null;
	Func<object> e2 = e1;
	
	Predicate<object> p1 = null;
	Predicate<string> p2 = p1;
	
	Func<object, ArgumentException> f1 = null;
	Func<string, Exception> f2 = f1;
}
