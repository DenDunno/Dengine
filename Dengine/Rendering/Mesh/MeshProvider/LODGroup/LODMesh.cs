
public class LODMesh : IDisposable
{
    public readonly MeshBinding Mesh;
    public readonly float Distance;

    public LODMesh(Mesh mesh, float distance)
    {
        Mesh = new MeshBinding(mesh);
        Distance = distance;
    }

    public void Dispose()
    {
        Mesh.Dispose();
    }
}