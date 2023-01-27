using OpenTK.Mathematics;

public class DynamicBatching : IDrawable
{
    private float[] _rawData;

    public DynamicBatching(Mesh[] data)
    {
        _rawData = StaticBatching.Concatenate(data).GetRawData();
    }

    public (int start, int end) GetSubData(int index, string attribute)
    {
        return (1, 2);
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