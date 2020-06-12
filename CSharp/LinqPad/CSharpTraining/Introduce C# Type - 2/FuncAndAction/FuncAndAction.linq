<Query Kind="Program" />

void Main()
{
	"Use Func and Action series".H1();
	"When to define delegate yourself".H2("blue");
	"1. use ref or out keyword".Info();
	"2. use params keyword".Info();
	"3. constrain parameter type".Info();
	"4. recursive delegate".Info();
	"5. more than 16 parameters".Info();
}

// See these delegates...
public delegate void TryCode(object userData);
public delegate void WaitCallback(object state);
public delegate void TimerCallback(object state);
public delegate void ContextCallback(object state);
public delegate void SendOrPostCallback(object state);
// ... 
// do not define similar signature delegate, use Func or Action instead.