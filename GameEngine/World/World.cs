using OpenTK.Windowing.Common;

public class World : EngineComponent
{
    public readonly List<GameObject> GameObjects;
    public readonly RenderQueue RenderQueue;

    public World(List<GameObject> gameObjects)
    {
        RenderQueue = new RenderQueue(gameObjects);
        GameObjects = gameObjects;
    }

    public override void Initialize()
    {
        for (int i = 0; i < GameObjects.Count; i++)
        {
            GameObjects[i].Initialize();
        }

        RenderQueue.Initialize();
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
        RenderQueue.Draw();
    }

    public override void OnResize(ResizeEventArgs obj)
    {
        RenderQueue.ResizeFrameBuffer(obj.Width, obj.Height);
    }
}