using OpenTK.Windowing.Common;

public class World : IEngineComponent
{
    public readonly IReadOnlyList<GameObject> GameObjects;
    private readonly Camera _camera;

    public World(Camera camera, IReadOnlyList<GameObject> gameObjects)
    {
        GameObjects = gameObjects;
        _camera = camera;
    }

    public void Initialize()
    {
        GameObjects.ForEach(gameObject => gameObject.Initialize());
    }

    public void Update(FrameEventArgs args)
    {
        float deltaTime = (float)args.Time;

        foreach (GameObject gameObject in GameObjects)
        {
            gameObject.Update(deltaTime);
        }
    }

    public void Draw(FrameEventArgs args)
    {
        foreach (GameObject gameObject in GameObjects)
        {
            gameObject.Draw(_camera.ProjectionMatrix, _camera.ViewMatrix);
        }
    }
}