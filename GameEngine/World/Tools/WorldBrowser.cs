
public class WorldBrowser
{
    public static WorldBrowser Instance = null!;
    private readonly World _world;

    public WorldBrowser(World world)
    {
        _world = world;
        Instance = this;
    }

    public T FindObjectOfType<T>() where T : IGameComponent
    {
        foreach (GameObject gameObject in _world.GameObjects)
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

    public GameObject FindGameObject(int id)
    {
        foreach (GameObject gameObject in _world.GameObjects)
        {
            if (gameObject.Data.Id == id)
            {
                return gameObject;
            }
        }
        
        throw new Exception($"No gameObject with id {id}");
    }

    public void Add(GameObject gameObject)
    {
        gameObject.Initialize();
        _world.GameObjects.Add(gameObject);
    }
    
    public void Destroy(GameObject gameObject)
    {
        gameObject.Dispose();
        _world.GameObjects.Remove(gameObject);
    }
}