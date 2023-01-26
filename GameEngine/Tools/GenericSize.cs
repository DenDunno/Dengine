using OpenTK.Mathematics;

public static class GenericSize
{
    private static readonly Dictionary<Type, int> _sizes = new()
    {
        {typeof(Vector3), 12},
        {typeof(Vector2), 8},
        {typeof(uint), 4},
        {typeof(int), 4},
    };

    private static int GetSize<T>()
    {
        return _sizes[typeof(T)];
    }

    public static int GetSize<T>(T[]? collection)
    {
        int result = 0;
        
        if (collection != null)
        {
            result = GetSize<T>();
        }

        return result;
    }
}