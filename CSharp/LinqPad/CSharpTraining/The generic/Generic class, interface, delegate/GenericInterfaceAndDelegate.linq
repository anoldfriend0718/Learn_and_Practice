<Query Kind="Program" />

void Main()
{
	"Generic interface and delegate".H1();
}

  public interface IEnumerator<out T> : IDisposable, IEnumerator
  {
    T Current { get; }
  }
  
  public delegate TReturn CallMe<TKey, TValue, TReturn>(TKey key, TValue value);