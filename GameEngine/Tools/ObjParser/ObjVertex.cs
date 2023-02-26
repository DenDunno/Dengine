using OpenTK.Mathematics;

public readonly struct ObjVertex
{
    public readonly Vector3 Position;
    public readonly Vector3 Normal;
    public readonly Vector2 TextureCoordinate;

    public ObjVertex(Vector3 position, Vector3 normal, Vector2 textureCoordinate)
    {
        Position = position;
        Normal = normal;
        TextureCoordinate = textureCoordinate;
    }
}