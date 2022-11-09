using OpenTK.Mathematics;

public class MeshData
{
    public readonly Vector3[] Positions;
    public Vector3[]? Normals { get; init; } = null;
    public Vector2[]? TextureCoordinates { get; init; } = null;

    public MeshData(Vector3[] positions)
    {
        Positions = positions;
    }
}