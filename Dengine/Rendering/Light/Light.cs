using OpenTK.Mathematics;

public class Light : IDrawable
{
    [EditorField] private readonly UniformData<LightData> _uniformData = new(1);
    [EditorField] private LightData _data;
    public readonly Transform Transform = new();

    public Light() : this(new LightData())
    {
    }
    
    public Light(LightData data)
    {
        _data = data;
    }

    void IGameComponent.Initialize()
    {
        _uniformData.Initialize();
    }
    
    void IDrawable.Draw()
    {
        _data.Position = new Vector4(Transform.Position);
        _uniformData.Map(_data);
    }

    public void Dispose()
    {
        _uniformData.Dispose();
    }
}