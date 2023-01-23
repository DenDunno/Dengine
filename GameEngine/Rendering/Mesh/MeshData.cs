using OpenTK.Mathematics;

public class MeshData
{
    public Vector3[] Positions { get; set; } = null!;
    public Vector3[]? Normals { get; init; }
    public Vector2[]? TextureCoordinates { get; set; }
    public uint[] Indices { get; init; } = null!;    
}   