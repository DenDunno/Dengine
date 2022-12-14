using OpenTK.Mathematics;

public class GameObject
{
    public readonly GameObjectData Data;

    public GameObject(GameObjectData data)
    {
        Data = data;
    }

    public void Initialize()
    {
        Data.Model.Initialize();
        Data.Components.ForEach(initializables => initializables.Initialize());
    }

    public void Update(float deltaTime)
    {
        Data.Components.ForEach(component => component.Update(deltaTime));
    }

    public void Draw(in Matrix4 projectionMatrix, in Matrix4 viewMatrix)
    {
        Data.Model.Draw(in projectionMatrix, in viewMatrix);
    }
}