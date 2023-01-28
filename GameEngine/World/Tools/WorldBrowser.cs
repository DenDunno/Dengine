
public static class WorldBrowser
{
    private static World _world = null!;

    public static void Setup(World world)
    {
        _world = world;
    }

    public static T FindObjectOfType<T>() where T : IGameComponent
    {
        return _world.GameObjects.Find<T>();
    }

    public static GameObject FindGameObject(int id)
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

    public static void Add(GameObject gameObject)
    {
        _world.GameObjects.Add(gameObject);
    }
    
    public static void Destroy(GameObject? gameObject)
    {
        if (gameObject == null)
        {
            DengineConsole.LogWarning("You tried to destroy null gameObject");
        }
        else
        {
            gameObject.Dispose();
            _world.GameObjects.Remove(gameObject);
        }
    }
}