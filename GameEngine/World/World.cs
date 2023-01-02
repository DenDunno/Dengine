using OpenTK.Windowing.Common;

public class World : EngineComponent
{
    public readonly IReadOnlyList<GameObject> GameObjects;
    private readonly Camera _camera;

    public World(Camera camera, IReadOnlyList<GameObject> gameObjects)
    {
        GameObjects = gameObjects;
        _camera = camera;
    }

    public override void Initialize()
    {
        GameObjects.ForEach(gameObject => gameObject.Initialize());
        Enabled = false;
    }

    public override void Update(FrameEventArgs args)
    {
        if (Enabled)
        {
            foreach (GameObject gameObject in GameObjects)
            {
                gameObject.Update((float)args.Time);
            }
        }
    }

    public override void Draw(FrameEventArgs args)
    {
        foreach (GameObject gameObject in GameObjects)
        {
            gameObject.Draw(_camera.ProjectionMatrix, _camera.ViewMatrix);
        }
    }
}