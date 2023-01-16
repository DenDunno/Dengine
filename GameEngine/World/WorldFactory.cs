
public abstract class WorldFactory
{
    protected PlayerInput Input { get; private set; } = null!;

    public World Create(PlayerInput playerInput)
    {
        Input = playerInput;
        
        List<GameObject> gameObjects = CreateGameObjects();

        return new World(gameObjects);
    }
    
    protected abstract List<GameObject> CreateGameObjects();
}