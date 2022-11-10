using System.Drawing;
using OpenTK.Mathematics;

public class NormalsViewer : TogglingComponent
{
    private readonly List<MeshWorldView> _meshs = new();

    public void Add(Transform transform, Mesh mesh)
    {
        MeshWorldView meshWorldView = new(transform, mesh);
        meshWorldView.CalculateNormals();
        _meshs.Add(meshWorldView);
    }

    protected override void OnUpdate(float deltaTime)
    {
        foreach (MeshWorldView meshWorldView in _meshs)
        {
            IReadOnlyCollection<MeshVertex> worldVertices = meshWorldView.GetWorldVertices();

            foreach (MeshVertex worldVertex in worldVertices)
            {
                foreach (Vector3 normal in worldVertex.Normals)
                {
                    Vector3 first = worldVertex.Position + normal * 0.2f;
                    Vector3 second = worldVertex.Position;
                
                    Gizmo.Instance.DrawLine(first, second, Color.Fuchsia);    
                }
            }
        }
    }
}