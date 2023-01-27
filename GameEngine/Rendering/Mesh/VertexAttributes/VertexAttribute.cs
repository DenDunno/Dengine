
public class VertexAttribute
{
    public readonly string Name;
    public readonly int Index;
    public readonly int Size;
    public readonly float[] Data;
    public int Offset;
    
    public VertexAttribute(string name, int index, int size, float[] data)
    {
        Index = index;
        Data = data;
        Name = name;
        Size = size;
    }
}