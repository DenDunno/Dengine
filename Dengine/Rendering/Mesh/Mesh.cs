
public class Mesh
{
    public readonly Dictionary<string, VertexAttribute> Attributes = new();
    public readonly int VerticesCount;
    
    public Mesh(List<VertexAttribute> attributes)
    {
        VerticesCount = attributes[0].Data.Length / attributes[0].Size;
        
        foreach (VertexAttribute attribute in attributes)
        {
            PushAttribute(attribute);   
        }
    }

    public VertexAttributeGroup AttributeGroup { get; private set; } = null!;
    public required uint[] Indices { get; init; } = Array.Empty<uint>();
    private int Stride => Attributes.Values.Sum(attribute => attribute.Size);

    public void PushAttribute(VertexAttribute attribute)
    {
        attribute.Offset = Stride;
        Attributes[attribute.Name] = attribute;
        AttributeGroup = new VertexAttributeGroup(Attributes.Values.ToArray(), Stride); // ToArray(): ValueCollection enumeration is too expensive
    }
    
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