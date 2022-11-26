using OpenTK.Mathematics;

public struct MeshVertex
{
    public Vector3 Position;
    public List<Vector3> Normals = new();

    public MeshVertex(Vector3 position, Vector3 normal)
    {
        Position = position;
        Normals = new List<Vector3>() { normal };
    }
}