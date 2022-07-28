
public class World : IDrawable, IUpdatable
{
    private readonly List<GameObject> _gameObjects;

    public World(List<GameObject> gameObjects)
    {
        _gameObjects = gameObjects;
    }

    public void Update(float deltaTime)
    {
        _gameObjects.ForEach(gameObject => gameObject.Update(deltaTime));
    }

    public void Draw()
    {
        _gameObjects.ForEach(gameObject => gameObject.Draw());
    }
}