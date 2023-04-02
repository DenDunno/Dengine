
public class GameObject : IDisposable
{
    public readonly GameObjectData Data;

    public GameObject(GameObjectData data)
    {
        Data = data;
    }

    public void Initialize()
    {
        Data.Components.InsertFirst(Data.Drawable);
        Data.Components.ForEach(initializables => initializables.Initialize());
    }

    public void Update(float deltaTime)
    {
        foreach (IGameComponent gameComponent in Data.Components)
        {
            gameComponent.Update(deltaTime);
        }
    }

    public void Draw()
    {
        Data.Drawable.Draw();
    }

    public void Dispose()
    {
        Data.Drawable.Dispose();
    }
}