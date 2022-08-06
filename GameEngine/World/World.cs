
public class World : IUpdatable
{
    private readonly List<GameObject> _gameObjects;
    private readonly Camera _camera;

    public World(List<GameObject> gameObjects, Camera camera)
    {
        _gameObjects = gameObjects;
        _camera = camera;
    }

    public void Initialize()
    {
        _gameObjects.ForEach(gameObject => gameObject.Initialize());
    }
    
    public void Update(float deltaTime)
    {
        _gameObjects.ForEach(gameObject => gameObject.Update(deltaTime));
    }

    public void Draw()
    {
        _gameObjects.ForEach(gameObject => gameObject.Draw(_camera.ProjectionViewMatrix));
    }
}