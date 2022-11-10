using OpenTK.Mathematics;

public class MeshData
{
    public Vector3[] Positions { get; init; } = null!;
    public Vector3[]? Normals { get; init; }
    public Vector2[]? TextureCoordinates { get; init; }
    public uint[] Indices { get; init; } = null!;
    public int RealVertexCount { get; init; }
}