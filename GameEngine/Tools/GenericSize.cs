using OpenTK.Mathematics;

public static class GenericSize
{
    private static readonly Dictionary<Type, int> _sizes = new()
    {
        {typeof(Vector3), 12},
        {typeof(Vector2), 8},
        {typeof(uint), 4},
        {typeof(int), 4},
        {typeof(float), 4},
        {typeof(byte), 1},
    };

    public static int Evaluate<T>()
    {
        return _sizes[typeof(T)];
    }
}