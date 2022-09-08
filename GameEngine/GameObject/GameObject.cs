using OpenTK.Mathematics;

public class GameObject
{
    private readonly GameObjectData _data;

    public GameObject(GameObjectData data)
    {
        _data = data;
    }

    public void Initialize()
    {
        _data.Model.Initialize();
        _data.Initializables.ForEach(initializables => initializables.Initialize());
    }

    public void Update(float deltaTime)
    {
        _data.Components.ForEach(component => component.Update(deltaTime));
    }

    public void Draw(in Matrix4 projectionMatrix, in Matrix4 viewMatrix)
    {
        _data.Model.Draw(in projectionMatrix, in viewMatrix);
    }
}