using OpenTK.Windowing.Common;

public class World : EngineComponent
{
    public readonly List<GameObject> GameObjects;
    private readonly RenderQueue _renderQueue;

    public World(List<GameObject> gameObjects)
    {
        _renderQueue = new RenderQueue(gameObjects);
        GameObjects = gameObjects;
    }

    public override void Initialize()
    {
        for (int i = 0; i < GameObjects.Count; i++)
        {
            GameObjects[i].Initialize();
        }

        _renderQueue.Initialize();
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
        _renderQueue.Draw();
    }

    public override void OnResize(ResizeEventArgs obj)
    {
        _renderQueue.ResizeFrameBuffer(obj.Width, obj.Height);
    }
}