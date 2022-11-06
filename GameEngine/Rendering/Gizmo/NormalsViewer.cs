using System.Drawing;
using OpenTK.Mathematics;

public class NormalsViewer : TogglingComponent
{
    private readonly List<MeshWorldView> _meshs = new();

    public void Add(Transform transform, Mesh mesh)
    {
        _meshs.Add(new MeshWorldView(transform, mesh));
    }

    protected override void OnUpdate(float deltaTime)
    {
        foreach (MeshWorldView meshWorldView in _meshs)
        {
            Vector3[] positions = meshWorldView.Positions;
            Vector3[] normals = meshWorldView.Normals;

            for (int i = 0; i < positions.Length; ++i)
            {
                Vector3 first = positions[i] + normals[i] * 0.2f;
                Vector3 second = positions[i];
                
                Gizmo.Instance.DrawLine(first, second, Color.Fuchsia);
            }
        }
    }
}