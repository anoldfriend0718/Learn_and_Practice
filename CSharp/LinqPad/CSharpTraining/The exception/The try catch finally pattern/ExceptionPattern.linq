<Query Kind="Program" />

void Main()
{
	"Exception pattern".H1();
	var c = new MyClass();
	
	"===== test1 ======".H2();
	c.Try1();
	
	"===== test2 ======".H2();
	try
	{
		c.Try2();
	}
	catch(Exception e)
	{
		e.StackTrace.Dump();
	}
	
	"===== test3 ======".H2();
	try
	{
		c.Try3();
	}
	catch(Exception e)
	{
		e.StackTrace.Dump();
	}
	
	// see functional style which no try catch to do same thing
}

public class MyClass
{
	private void Throw()
	{
		throw new ArgumentException("my exception.");
	}
	
	public void Try1()
	{
		try
		{
			Throw();
		}
		catch
		{
			"Exception occured.".Dump();
		}
		finally
		{
			"Do some clean work".Dump();
		}
	}
	
	public void Try2()
	{
		try
		{
			Throw();
		}
		catch(ArgumentException ae)
		{
			"ArgumentException occured.".Dump();
			throw;
		}
		catch(Exception)
		{
			"Exception occured.".Dump();
			throw;
		}
		finally
		{
			"Do some clean work".Dump();
		}
	}	
	
	public void Try3()
	{
		try
		{
			Throw();
		}
		catch(ArgumentException ae)
		{
			"ArgumentException occured.".Dump();
			throw ae;
		}
		catch(Exception e)
		{
			"Exception occured.".Dump();
			throw e;
		}
		finally
		{
			"Do some clean work".Dump();
		}
	}	
}