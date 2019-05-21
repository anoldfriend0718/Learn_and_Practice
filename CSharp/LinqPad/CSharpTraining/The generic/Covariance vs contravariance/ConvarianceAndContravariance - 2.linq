<Query Kind="Program" />

void Main()
{
	"Convariance and contravariance - Generic".H1();
	MyFunc<Child, Parent> myFunc = null;

	M(myFunc);

	myFunc = Run;
}


public delegate R MyFunc<in T, out R>(T arg);

public class Ancestor { }
public class Parent : Ancestor { }
public class Child : Parent { }
public class Grandson : Child { }

public Child Run(Parent arg)
{
	return null;
}

public Ancestor M(MyFunc<Grandson, Ancestor> arg)
{
	return arg?.Invoke(null);
}