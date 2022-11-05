using GameEngine.Extensions;
using OpenTK.Mathematics;

public class Mesh
{
    public readonly Vector3[] Positions;
    public readonly uint[] Indices;
    private readonly List<VertexAttribute> _attributes = new();
    
    public Mesh(Vector3[] positions, uint[] indices)
    {
        Positions = positions;
        Indices = indices;
    }

    public Vector3[]? Normals { get; init; }
    public Vector2[]? TextureCoordinates { get; init; }
    public Vector3[]? Color { get; init; } = null;
    
    public int VertexCount => Positions.Length;
    public int Stride => _attributes.Sum(attribute => attribute.Size);
    public VertexAttributeGroup AttributeGroup => new(_attributes, Stride);

    public void Init()
    {
        TryAddAttribute(Positions);
        TryAddAttribute(Normals);
        TryAddAttribute(TextureCoordinates);
        TryAddAttribute(Color);
    }

    public float[] GetVerticesData()
    {
        int stride = Stride;
        int vertexCount = VertexCount;
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

        return verticesData;
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