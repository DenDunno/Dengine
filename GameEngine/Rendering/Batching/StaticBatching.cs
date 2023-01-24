using OpenTK.Mathematics;

public static class StaticBatching
{
    public static MeshData Concatenate(IList<MeshData> objects)
    {
        return new MeshData
        {
            Positions = ConcatenatePositions(objects),
            Indices = ConcatenateIndices(objects),
            TextureCoordinates = ConcatenateTextureCoordinates(objects),
            Normals = ConcatenateNormals(objects)
        };
    }

    private static Vector3[] ConcatenatePositions(IList<MeshData> objects)
    {
        int count = objects.Sum(meshData => meshData.Positions.Length);
        Vector3[] buffer = new Vector3[count];
        int index = 0;
        
        foreach (MeshData meshData in objects)
        {
            for (int i = 0; i < meshData.Positions.Length; ++i, ++index)
            {
                buffer[index] = meshData.Positions[i];
            }
        }

        return buffer;
    }

    private static uint[] ConcatenateIndices(IList<MeshData> objects)
    {
        int count = objects.Sum(meshData => meshData.Indices.Length);
        uint[] buffer = new uint[count];
        int index = 0;
        uint offset = 0;
        
        foreach (MeshData meshData in objects)
        {
            for (int i = 0; i < meshData.Indices.Length; ++i, ++index)
            {
                buffer[index] = meshData.Indices[i] + offset;
            }

            offset += (uint)meshData.Positions.Length;
        }

        return buffer;
    }

    private static Vector3[]? ConcatenateNormals(IList<MeshData> objects)
    {
        if (objects.First().Normals == null)
            return null;
        
        int count = objects.Sum(meshData => meshData.Normals!.Length);
        Vector3[] buffer = new Vector3[count];
        int index = 0;
        
        foreach (MeshData meshData in objects)
        {
            for (int i = 0; i < meshData.Normals!.Length; ++i, ++index)
            {
                buffer[index] = meshData.Normals[i];
            }
        }

        return buffer;
    }

    private static Vector2[]? ConcatenateTextureCoordinates(IList<MeshData> objects)
    {
        if (objects.First().TextureCoordinates == null)
            return null;
        
        int count = objects.Sum(meshData => meshData.TextureCoordinates!.Length);
        Vector2[] buffer = new Vector2[count];
        int index = 0;
        
        foreach (MeshData meshData in objects)
        {
            for (int i = 0; i < meshData.TextureCoordinates!.Length; ++i, ++index)
            {
                buffer[index] = meshData.TextureCoordinates[i];
            }
        }

        return buffer;
    }
}