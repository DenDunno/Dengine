
public static class EnumerableExtensions
{
    public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
    {
        foreach (T element in collection)
        {
            action(element);
        }
    }

    public static void InsertFirst<T>(this List<T> collection, T element)
    {
        collection.Insert(0, element);
    }
}