using OpenTK.Mathematics;

public class DynamicBatching : IDrawable
{
    private readonly MeshData[] _data;

    public DynamicBatching(MeshData[] data)
    {
        _data = data;
    }

    void IGameComponent.Initialize()
    {
    }
    
    public void Draw(in Matrix4 projectionMatrix, in Matrix4 viewMatrix)
    {
    }

    public void Dispose()
    {
    }
}