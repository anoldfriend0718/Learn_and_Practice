<Query Kind="Program" />

void Main()
{
	"Delegate Variance".H1();
	
	MyDel delegate1 = Method1;
	MyDel delegate2 = Method2;
	MyDel delegate3 = Method3;
	MyDel delegate4 = Method4;
}

public delegate Parent MyDel(Child arg);

public class Parent{}
public class Child : Parent {}

public Parent Method1(Child arg)
{
	return null;
}


public Child Method2(Child arg)
{
	return null;
}

public Child Method3(Parent arg)
{
	return null;
}

public Parent Method4(Parent arg)
{
	return null;
}