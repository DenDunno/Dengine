
public class WorldBrowser
{
    private readonly World _world;

    public WorldBrowser(World world)
    {
        _world = world;
    }

    public T FindFirst<T>() where T : TogglingComponent
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
}