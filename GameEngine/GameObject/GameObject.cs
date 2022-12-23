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
        Data.Components.Add(Data.Model);
        Data.Components.ForEach(initializables => initializables.Initialize());
    }

    public void Update(float deltaTime)
    {
        for (int i = 0; i < Data.Components.Count; ++i)
        {
            Data.Components[i].Update(deltaTime);
        }
    }

    public void Draw(in Matrix4 projectionMatrix, in Matrix4 viewMatrix)
    {
        Data.Model.Draw(in projectionMatrix, in viewMatrix);
    }
}