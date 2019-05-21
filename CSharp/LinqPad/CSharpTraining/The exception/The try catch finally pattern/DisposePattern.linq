<Query Kind="Program" />

void Main()
{
	"Dispose Pattern".H1();
	var instance = new MyClass();
	instance = null;
	GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
}

// Define other methods and classes here
public class MyClass : IDisposable
{
	private Boolean disposed;

	protected virtual void Dispose(Boolean disposing)
	{
		if (disposed)
		{
			return;
		}

		if (disposing)
		{
			//Managed cleanup code here, while managed refs still valid
		}
		//Unmanaged cleanup code here

		disposed = true;
	}

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	~MyClass()
	{
		Dispose(false);
		"Deconstructor called".H4("red");
	}
}