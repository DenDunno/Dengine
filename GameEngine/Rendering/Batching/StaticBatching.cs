
public static class StaticBatching
{
    public static Mesh Concatenate(IList<Mesh> objects)
    {
        return new Mesh(ConcatenateAttributes(objects))
        {
            Indices = ConcatenateIndices(objects),
        };
    }

    private static List<VertexAttribute> ConcatenateAttributes(IList<Mesh> objects)
    {
        List<VertexAttribute> result = new();
        int verticesCount = objects.Sum(mesh => mesh.VerticesCount);
        
        foreach (KeyValuePair<string, VertexAttribute> attribute in objects.First().Attributes)
        {
            float[] buffer = new float[verticesCount * attribute.Value.Size];
            string attributeName = attribute.Key;
            int destinationIndex = 0;
            
            foreach (Mesh mesh in objects)
            {
                float[] subData = mesh.Attributes[attributeName].Data;
                Array.Copy(subData, 0, buffer, destinationIndex, subData.Length);
                destinationIndex += subData.Length;
            }
            
            result.Add(new VertexAttribute(attributeName, attribute.Value.Index, attribute.Value.Size, buffer));
        }

        return result;
    }

    private static uint[] ConcatenateIndices(IList<Mesh> objects)
    {
        int count = objects.Sum(meshData => meshData.Indices.Length);
        uint[] buffer = new uint[count];
        int index = 0;
        uint offset = 0;
        
        foreach (Mesh meshData in objects)
        {
            for (int i = 0; i < meshData.Indices.Length; ++i, ++index)
            {
                buffer[index] = meshData.Indices[i] + offset;
            }

            offset += (uint)meshData.VerticesCount;
        }

        return buffer;
    }
}