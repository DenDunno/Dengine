using OpenTK.Windowing.Common;

public class World 
{
    public readonly IReadOnlyCollection<GameObject> GameObjects;
    private readonly Camera _camera;

    public World(Camera camera, IReadOnlyCollection<GameObject> gameObjects)
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
        GameObjects.ForEach(gameObject => gameObject.Update((float)args.Time));
    }

    public void Draw(FrameEventArgs obj)
    {
        GameObjects.ForEach(gameObject => gameObject.Draw(_camera.ProjectionMatrix, _camera.ViewMatrix));
    }
}