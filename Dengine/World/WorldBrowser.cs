
public static class WorldBrowser
{
    private static List<GameObject> _gameObjects = null!;
    
    public static void Setup(List<GameObject> gameObjects)
    {
        _gameObjects = gameObjects;
    }

    public static T FindObjectOfType<T>() where T : IGameComponent
    {
        return _gameObjects.Find<T>();
    }

    public static GameObject FindGameObject(int id)
    {
        foreach (GameObject gameObject in _gameObjects)
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
        _gameObjects.Add(gameObject);
    }
    
    public static void Destroy(GameObject? gameObject)
    {
        if (gameObject == null)
        {
            DengineConsole.Instance.LogWarning("You tried to destroy null gameObject");
        }
        else
        {
            gameObject.Dispose();
            _gameObjects.Remove(gameObject);
        }
    }
}