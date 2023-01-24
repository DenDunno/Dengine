using OpenTK.Mathematics;

public class GameObject : IDisposable
{
    public readonly GameObjectData Data;

    public GameObject(GameObjectData data)
    {
        Data = data;
    }

    public void Initialize()
    {
        Data.Components.Add(Data.Drawable);
        Data.Components.ForEach(initializables => initializables.Initialize());
    }

    public void Update(float deltaTime)
    {
        foreach (IGameComponent gameComponent in Data.Components)
        {
            gameComponent.Update(deltaTime);
        }
    }

    public void Draw(in Matrix4 projectionMatrix, in Matrix4 viewMatrix)
    {
        Data.Drawable.Draw(in projectionMatrix, in viewMatrix);
    }

    public void Dispose()
    {
        Data.Drawable.Dispose();
    }
}