using OpenTK.Windowing.Common;

public class World : EngineComponent
{
    public readonly List<GameObject> GameObjects;
    private readonly Camera _camera;

    public World(Camera camera, List<GameObject> gameObjects)
    {
        GameObjects = gameObjects;
        _camera = camera;
    }

    public override void Initialize()
    {
        for (int i = 0; i < GameObjects.Count; i++)
        {
            GameObjects[i].Initialize();
        }
        
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