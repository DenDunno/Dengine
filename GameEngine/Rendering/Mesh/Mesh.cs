
public class Mesh
{
    public readonly Dictionary<string, VertexAttribute> Attributes = new();

    public Mesh(List<VertexAttribute> attributes)
    {
        foreach (VertexAttribute attribute in attributes)
        {
            attribute.Offset = Stride;
            Attributes[attribute.Name] = attribute;
        }
    }

    public VertexAttributeGroup AttributeGroup => new(Attributes.Values, Stride);
    public uint[] Indices { get; init; } = Array.Empty<uint>();
    
    public int VerticesCount => Attributes.Values.First().Data.Length / Attributes.Values.First().Size;
    private int Stride => Attributes.Values.Sum(attribute => attribute.Size);

    public float[] GetRawData()
    {
        float[] verticesData = new float[Stride * VerticesCount];

        for (int i = 0, dataIndex = 0; i < VerticesCount; ++i)
        {
            foreach (VertexAttribute attribute in Attributes.Values)
            {
                int attributeDataIndex = i * attribute.Size;
                int limit = attributeDataIndex + attribute.Size;

                while (attributeDataIndex < limit)
                {
                    verticesData[dataIndex] = attribute.Data[attributeDataIndex];
                    
                    ++dataIndex;
                    ++attributeDataIndex;
                }
            }    
        }
        
        return verticesData;
    }
}