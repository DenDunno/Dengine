
public class VertexAttribute
{
    public readonly int Index;
    public readonly float[] Data;
    public readonly int Size;

    public VertexAttribute(int index, float[] data, int size)
    {
        Index = index;
        Data = data;
        Size = size;
    }
}