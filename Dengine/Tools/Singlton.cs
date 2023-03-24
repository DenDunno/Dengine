
public abstract class Singlton<T> where T : new()
{
    public static T Instance { get; } = new();
}