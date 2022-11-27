using OpenTK.Mathematics;

public class ConvexHull : CollisionMesh
{
    public ConvexHull(Mesh mesh, Transform transform) : base(mesh, transform)
    {
    }

    protected override Vector3[] CalculateMesh()
    {
        return Mesh.Data.Positions;
    }
}