using OpenTK.Mathematics;

public readonly struct MeshVertex
{
    public readonly Vector3 Position;
    public readonly Vector2 TextureCoordinates;
    public readonly Vector3 Normal;

    public MeshVertex(Vector3 position, Vector2 textureCoordinates, Vector3 normal)
    {
        Position = position;
        TextureCoordinates = textureCoordinates;
        Normal = normal;
    }
}