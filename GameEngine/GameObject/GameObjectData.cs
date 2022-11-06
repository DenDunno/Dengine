
public class GameObjectData
{
    public readonly string Name;

    public GameObjectData(string name)
    {
        Name = name;
    }
    
    public IModel Model { get; init; } = new Point();
    public IInitializable[] Initializables { get; init; } = Array.Empty<IInitializable>();
    public IUpdatable[] Components { get; init; } = Array.Empty<IUpdatable>();
}