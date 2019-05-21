<Query Kind="Program" />

void Main()
{
	"Implement a Iterator".H1();
}

public enum IteratorState
{
    Create = -2,
    Start = 0,
    MoveNext = 1,
    End = -1,
    Error = -3
}

public class Iterator<T> : IEnumerator<T>
{
    private readonly Action start;

    private readonly Func<bool> moveNext;

    private readonly Func<T> getCurrent;

    private readonly Action dispose;

    private readonly Action end;

    public Iterator(
        Action start = null,
        Func<bool> moveNext = null,
        Func<T> getCurrent = null,
        Action dispose = null,
        Action end = null)
    {
        this.start = start;
        this.moveNext = moveNext;
        this.getCurrent = getCurrent;
        this.dispose = dispose;
        this.end = end;
    }

    public T Current { get; private set; }

    object IEnumerator.Current => this.Current;

    internal IteratorState State { get; private set; } = IteratorState.Create; // IteratorState: Create.

    internal Iterator<T> Start()
    {
        this.State = IteratorState.Start;  // IteratorState: Create => Start.
        return this;
    }

    public bool MoveNext()
    {
        try
        {
            switch (this.State)
            {
                case IteratorState.Start:
                    this.start?.Invoke();
                    this.State = IteratorState.MoveNext; // IteratorState: Start => MoveNext.
                    goto case IteratorState.MoveNext;
                case IteratorState.MoveNext:
                    if (this.moveNext?.Invoke() ?? false)
                    {
                        this.Current = this.getCurrent != null ? this.getCurrent() : default;
                        return true; // IteratorState: MoveNext => MoveNext.
                    }
                    this.State = IteratorState.End; // IteratorState: MoveNext => End.
                    this.dispose?.Invoke();
                    this.end?.Invoke();
                    break;
            }
            return false;
        }
        catch
        {
            this.State = IteratorState.Error; // IteratorState: Start, MoveNext, End => Error.
            this.Dispose();
            throw;
        }
    }

    public void Dispose()
    {
        if (this.State == IteratorState.Error || this.State == IteratorState.MoveNext)
        {
            try { }
            finally
            {
                // Unexecuted finally blocks are executed before the thread is aborted.
                this.State = IteratorState.End; // IteratorState: Error => End.
                this.dispose?.Invoke();
            }
        }
    }

    public void Reset() => throw new NotSupportedException();
}