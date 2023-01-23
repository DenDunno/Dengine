
public class GameObjectData
{
    public string Name;
    public readonly Transform Transform;
    public readonly int Id = GameObjectId.Value;
    public List<IGameComponent> Components { get; init; } = new();
    public IModel Model { get; set; } = new Point();

    public GameObjectData(string name, Transform transform)
    {
        Name = name;
        Transform = transform;
    }
}