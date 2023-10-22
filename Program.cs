class Program
{
    private static event Action<int> addSubscriber;
    private static event Action<int> removeSubscriber;
   
    static void Main(string[] args)
    {
        ObservableIntStack stack = new ObservableIntStack(new int[]{1,2,3,4});

        addSubscriber += Sub1Action;
        addSubscriber += Sub2Action;
        removeSubscriber += SubRemoved;

        stack.Subscribe(addSubscriber);
        stack.Unsubscribe(removeSubscriber);
        stack.Push(1);
        stack.Push(2);
        stack.Pop();
        stack.Pop();
    }
   
    private static void Sub1Action(int item)
    {
        Console.WriteLine($"{item} for first subscriber");
    }
   
    private static void Sub2Action(int item)
    {
        Console.WriteLine($"{item} for second subscriber");
    }
   
    private static void SubRemoved(int item)
    {
        Console.WriteLine($"removed {item}");
    }
}