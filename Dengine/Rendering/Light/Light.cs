
public class Light : IDrawable
{
    [EditorField] private readonly LightUniformBuffer _uniformBuffer;
    public readonly Transform Transform = new();

    public Light() : this(new LightData())
    {
    }
    
    public Light(LightData data)
    {
        _uniformBuffer = new LightUniformBuffer(Transform, data);
    }

    void IGameComponent.Initialize()
    {
        _uniformBuffer.Initialize();
    }
    
    void IDrawable.Draw()
    {
        _uniformBuffer.Map();
    }

    public void Dispose()
    {
        _uniformBuffer.Dispose();
    }
}