using OpenTK.Mathematics;

public class Light : IDrawable
{
    [EditorField] private readonly UniformData<LightData> _uniformData = new(1);
    public readonly Transform Transform;

    public Light() : this(new Transform(), new LightData())
    {
    }
    
    public Light(Transform transform) : this(transform, new LightData())
    {
    }
    
    public Light(LightData data) : this(new Transform(), data)
    {
    }
    
    public Light(Transform transform, LightData data)
    {
        Transform = transform;
        _uniformData.Data = data;
    }

    void IGameComponent.Initialize()
    {
        _uniformData.Initialize();
    }
    
    void IDrawable.Draw()
    {
        _uniformData.Data.Position = new Vector4(Transform.Position);
        _uniformData.Map();
    }

    public void Dispose()
    {
        _uniformData.Dispose();
    }
}