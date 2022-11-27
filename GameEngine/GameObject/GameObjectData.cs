
public class GameObjectData
{
    public readonly string Name;
    public readonly List<IInitializable> Initializables = new();
    public readonly List<IUpdatable> Components = new();

    public GameObjectData(string name)
    {
        Name = name;
    }
    
    public IModel Model { get; init; } = new Point();
    public object[] Dependencies { set => SetDependencies(value); }

    private void SetDependencies(object[] dependencies)
    {
        foreach (object dependency in dependencies)
        {
            TryAddComponentToCollection(dependency, Initializables);
            TryAddComponentToCollection(dependency, Components);
        }
    }

    private void TryAddComponentToCollection<T>(object dependency, ICollection<T> collection)
    {
        if (dependency is T typedDependency)
        {
            collection.Add(typedDependency);
        }
    }
}