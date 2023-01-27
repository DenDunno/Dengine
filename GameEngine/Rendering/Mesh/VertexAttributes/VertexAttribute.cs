
public class VertexAttribute
{
    public readonly int Index;
    public readonly int Size;
    public readonly int Offset;
    public float[] Data;

    public VertexAttribute(int index, int size, int offset, float[] data)
    {
        Index = index;
        Data = data;
        Size = size;
        Offset = offset;
    }

    public void Release()
    {
        Data = null!;
    }
}