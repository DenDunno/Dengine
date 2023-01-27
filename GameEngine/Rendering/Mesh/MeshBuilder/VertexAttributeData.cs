
public readonly struct VertexAttributeData
{
    public readonly string Name;
    public readonly int Size;
    public readonly float[] Data;
    
    public VertexAttributeData(string name, int size, float[] data)
    {
        Name = name;
        Size = size;
        Data = data;
    }
}