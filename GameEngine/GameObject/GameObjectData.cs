
public class GameObjectData
{
    public IModel Model { get; init; } = new Point();
    public IInitializable[] Initializables { get; init; } = Array.Empty<IInitializable>();
    public IUpdatable[] Components { get; init; } = Array.Empty<IUpdatable>();
}