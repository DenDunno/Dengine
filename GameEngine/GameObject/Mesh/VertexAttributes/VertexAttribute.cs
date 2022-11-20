
public class VertexAttribute
{
    public readonly int Index;
    public readonly float[] Data;
    public readonly int Size;
    public readonly int Offset;

    public VertexAttribute(int index, float[] data, int size, int offset)
    {
        Index = index;
        Data = data;
        Size = size;
        Offset = offset;
    }
}