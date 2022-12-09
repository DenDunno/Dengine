
public class WorldBrowser
{
    private readonly World _world;

    public WorldBrowser(World world)
    {
        _world = world;
    }

    public T FindFirst<T>() where T : GameComponent
    {
        foreach (GameObject gameObject in _world.GameObjects)
        {
            foreach (IUpdatable component in gameObject.Data.Components)
            {
                if (component is T result)
                {
                    return result;
                }
            }
        }

        throw new Exception($"No component with type {typeof(T)}");
    }
}