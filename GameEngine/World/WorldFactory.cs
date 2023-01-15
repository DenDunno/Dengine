
public abstract class WorldFactory
{
    protected PlayerInput Input { get; private set; } = null!;

    public World Create(PlayerInput playerInput)
    {
        Input = playerInput;
        
        List<GameObject> gameObjects = CreateGameObjects();
        Camera camera = gameObjects.Find<Camera>();
        
        return new World(camera, gameObjects);
    }
    
    protected abstract List<GameObject> CreateGameObjects();
}