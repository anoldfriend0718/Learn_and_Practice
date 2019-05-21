<Query Kind="Program" />

void Main()
{
	"IEnumerable and IEnumerator".H1();
}
  public interface IEnumerable
  {
    IEnumerator GetEnumerator();
  }
  
  public interface IEnumerable<out T> : IEnumerable
  {
    IEnumerator<T> GetEnumerator();
  }

  public interface IEnumerator
  {
    object Current { get; }

    bool MoveNext();

    void Reset();
  }
  
  public interface IEnumerator<out T> : IDisposable, IEnumerator
  {
    T Current { get; }
  }