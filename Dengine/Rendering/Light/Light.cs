using OpenTK.Mathematics;

public class Light : IDrawable
{
    public readonly Transform Transform;
    [EditorField] private readonly UniformData<LightData> _uniformData = new(1);

    public Light() : this(new Transform(), new LightData())
    {
    }
    
    public Light(Transform transform) : this(transform, new LightData())
    {
    }
    
    public Light(LightData data) : this(new Transform(), data)
    {
    }
    
    public Light(Transform transform, LightData value)
    {
        Transform = transform;
        _uniformData.Value = value;
    }

    void IGameComponent.Initialize()
    {
        _uniformData.Initialize();
    }
    
    void IDrawable.Draw()
    {
        _uniformData.Value.Position = new Vector4(Transform.Position);
        _uniformData.Map();
    }

    public void Dispose()
    {
        _uniformData.Dispose();
    }
}