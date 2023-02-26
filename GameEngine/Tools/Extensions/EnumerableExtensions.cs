
public static class EnumerableExtensions
{
    public static T[] CreateFilledArray<T>(int count) where T : new()
    {
        T[] array = new T[count];
        
        for (int i = 0; i < array.Length; ++i)
        {
            array[i] = new T();
        }

        return array;
    }
    
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

    public static T GetRandomElement<T>(this HashSet<T> hashSet)
    {
        int randomIndex = new Random().Next(hashSet.Count);

        return hashSet.ElementAt(randomIndex);
    }
    
    public static T GetRandomElement<T>(this IReadOnlyList<T> collection)
    {
        int randomIndex = new Random().Next(collection.Count);

        return collection[randomIndex];
    }
    
    public static bool IsNotEmpty<T>(this IEnumerable<T> collection)
    {
        return collection.Count() != 0;
    }

    public static T Find<T>(this IEnumerable<GameObject> gameObjects) where T : IGameComponent
    {
        foreach (GameObject gameObject in gameObjects)
        {
            foreach (IGameComponent component in gameObject.Data.Components)
            {
                if (component is T result)
                {
                    return result;
                }
            }
        }

        throw new Exception($"No component with type {typeof(T)}");
    }
    
    public static T GetComponent<T>(this GameObject gameObject) where T : IGameComponent
    {
        foreach (IGameComponent component in gameObject.Data.Components)
        {
            if (component is T result)
            {
                return result;
            }
        }

        throw new Exception($"No component with type {typeof(T)}");
    }
}