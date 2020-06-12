<Query Kind="Program" />

void Main()
{
	"Define Lambda".H1();
	// no parameter lambda
	Func<int> a = () => 1;
	// one parameter lambda
	Func<int, int> b = x => 1;
	// 2 or more parameters lambda
	Func<int, int, int> c = (x, y) => 1;
	// multiline lambda
	Func<int, int, string> d = (x, y) =>
	  {
		  var ret = x + y;
		  return ret.ToString();
	  };
}

// Define other methods and classes here