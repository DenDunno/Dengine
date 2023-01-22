using OpenTK.Mathematics;

public class Mesh
{
    public readonly MeshData Data;
    private readonly List<VertexAttribute> _attributes = new();
    
    public Mesh(MeshData data)
    {
        Data = data;
    }

    public VertexAttributeGroup AttributeGroup => new(_attributes, Stride);
    private int Stride => _attributes.Sum(attribute => attribute.Size);

    public void Init()
    {
        TryAddAttribute(Data.Positions);
        TryAddAttribute(Data.Normals);
        TryAddAttribute(Data.TextureCoordinates);
    }

    public float[] GetVerticesData()
    {
        int stride = Stride;
        int vertexCount = Data.Positions.Length;
        float[] verticesData = new float[stride * vertexCount];
        int verticesDataIndex = 0;

        for (int i = 0; i < vertexCount; ++i)
        {
            foreach (VertexAttribute attribute in _attributes)
            {
                int attributeDataIndex = i * attribute.Size;
                int limit = attributeDataIndex + attribute.Size;

                while (attributeDataIndex < limit)
                {
                    verticesData[verticesDataIndex] = attribute.Data[attributeDataIndex];
                    
                    ++verticesDataIndex;
                    ++attributeDataIndex;
                }
            }    
        }

        //Release();

        return verticesData;
    }

    public void Release()
    {
        foreach (VertexAttribute vertexAttribute in _attributes)
        {
            vertexAttribute.Release();
        }
    }

    private void TryAddAttribute(Vector3[]? positions)
    {
        if (positions != null)
        {
            AddAttribute(positions.ToFloatArray(), 3);
        }
    }
    
    private void TryAddAttribute(Vector2[]? positions)
    {
        if (positions != null)
        {
            AddAttribute(positions.ToFloatArray(), 2);
        }
    }

    private void AddAttribute(float[] data, int elementSize)
    {
        _attributes.Add(new VertexAttribute(_attributes.Count, data, elementSize, Stride));
    }
}