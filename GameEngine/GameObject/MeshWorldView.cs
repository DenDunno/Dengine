using OpenTK.Mathematics;

public class MeshWorldView
{
    private readonly Transform _transform;
    private readonly Mesh _mesh;

    public MeshWorldView(Transform transform, Mesh mesh)
    {
        _transform = transform;
        _mesh = mesh;
    }
    
    public Vector3[] Positions 
    {
        get
        {
            Matrix4 modelMatrix = _transform.ModelMatrix;
            var worldPositions = new Vector3[_mesh.Positions.Length];

            for (int i = 0; i < _mesh.Positions.Length; ++i)
            {
                var vertex = new Vector4(_mesh.Positions[i], 1);
                worldPositions[i] = (vertex * modelMatrix).Xyz;
            }

            return worldPositions;
        }
    }
}