
public static class StaticBatching
{
    public static Mesh Concatenate(IEnumerable<IMeshDataSource> sources)
    {
        Mesh[] meshes = sources.Select(source => source.Build()).ToArray();
        
        return Concatenate(meshes);
    }
    
    public static Mesh Concatenate(IList<Mesh> objects)
    {
        return new Mesh(ConcatenateAttributes(objects, 0, objects.Count))
        {
            Indices = ConcatenateIndices(objects, 0, objects.Count),
        };
    }
    
    public static Mesh[] ConcatenateIntoParts(IList<Mesh> objects, int parts)
    {
        Mesh[] result = new Mesh[parts];
        int partSize = objects.Count / parts;
        
        for (int i = 0; i < parts; ++i)
        {
            int startIndex = partSize * i;
            int endIndex = partSize * (i + 1);

            if (i == parts - 1)
            {
                endIndex = objects.Count;
            }
            
            result[i] = new Mesh(ConcatenateAttributes(objects, startIndex, endIndex))
            {
                Indices = ConcatenateIndices(objects, startIndex, endIndex),
            };
        }

        return result;
    }

    private static List<VertexAttribute> ConcatenateAttributes(IList<Mesh> objects, int startIndex, int endIndex)
    {
        List<VertexAttribute> result = new();
        int verticesCount = objects.Sum(startIndex, endIndex, mesh => mesh.VerticesCount);
        
        foreach (KeyValuePair<string, VertexAttribute> attribute in objects.First().Attributes)
        {
            float[] buffer = new float[verticesCount * attribute.Value.Size];
            string attributeName = attribute.Key;
            int destinationIndex = 0;

            for (int i = startIndex; i < endIndex; ++i)
            {
                float[] subData = objects[i].Attributes[attributeName].Data;
                Array.Copy(subData, 0, buffer, destinationIndex, subData.Length);
                destinationIndex += subData.Length;
            }

            result.Add(new VertexAttribute(attributeName, attribute.Value.Index, attribute.Value.Size, buffer));
        }

        return result;
    }

    private static uint[] ConcatenateIndices(IList<Mesh> objects, int startIndex, int endIndex)
    {
        int count = objects.Sum(startIndex, endIndex, meshData => meshData.Indices.Length);
        uint[] buffer = new uint[count];
        int index = 0;
        uint offset = 0;

        for (int i = startIndex; i < endIndex; ++i)
        {
            for (int j = 0; j < objects[i].Indices.Length; ++j, ++index)
            {
                buffer[index] = objects[i].Indices[j] + offset;
            }

            offset += (uint)objects[i].VerticesCount;
        }

        return buffer;
    }
}