<Query Kind="Program" />

void Main()
{
	"Yield with finally".H1();
    DateTime stop = DateTime.Now.AddSeconds(2);
    foreach (int i in CountWithTimeLimit(stop))
    {
        Console.WriteLine("Received {0}", i);
        Thread.Sleep(300);
    }    
}

static IEnumerable<int> CountWithTimeLimit(DateTime limit)
{
    try
    {
        for (int i = 1; i <= 100; i++)
        {
            if (DateTime.Now >= limit)
            {
                yield break;
            }
            yield return i;
        }
    }
    finally
    {
        Console.WriteLine("Stopping!");
    }
}