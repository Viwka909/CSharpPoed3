public class ObservableIntStack
{
    public event Action<int> OnItemAdded;
    public event Action<int> OnItemRemoved;
    private Stack<int> stack;

    public ObservableIntStack(IEnumerable<int> values)
    {
        stack = new Stack<int>();
        foreach (var i in values)
        {
            stack.Push(i);
        }
    }

    public int Count => stack.Count;

    public void Subscribe(Action<int> subscriber)
    {
        if (subscriber == null)
        {
            throw new ArgumentNullException();
        }

        OnItemAdded += subscriber;
    }
    public void Unsubscribe(Action<int> subscriber)
    {
        if (subscriber == null)
        {
            throw new ArgumentNullException();
        }

        OnItemRemoved += subscriber;
    }
    public void Push(int item)
    {
        stack.Push(item);
        OnItemAdded(item);
    }
    public int Pop()
    {
        int item = stack.Pop();
        OnItemRemoved(item);
        return item;
    }

    public int Peek() => stack.Peek();

}