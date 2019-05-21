<Query Kind="Program" />

void Main()
{
	"Define interface".H1();

	typeof(Interface5)
		.GetInterfaces()
		.Append(typeof(Interface5))
		.SelectMany(t => t.GetMethods(), (t, m) => $"{m.Name} defined in {t.Name}")
		.Dump("All methods in Interface5");
}

public interface Interface1
{
	void Run1();
}

public interface Interface2
{
	void Run2();
}

public interface Interface3 : Interface1, Interface2
{
	void Run3();
}

public interface Interface4
{
	void Run4();
}

public interface Interface5 : Interface3, Interface4
{
	void Run5();
}