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
            Vector3[] worldPositions = new Vector3[_mesh.Positions.Length];

            for (int i = 0; i < _mesh.Positions.Length; ++i)
            {
                Vector4 vertex = new(_mesh.Positions[i], 1);
                worldPositions[i] = (vertex * modelMatrix).Xyz;
            }

            return worldPositions;
        }
    }
    
    public Vector3[] Normals 
    {
        get
        {
            Matrix4 modelMatrix = _transform.ModelMatrix;
            Vector3[] normals = new Vector3[_mesh.Normals.Length];

            for (int i = 0; i < _mesh.Normals.Length; ++i)
            {
                Vector4 normal = new(_mesh.Normals[i], 0);
                normals[i] = (normal * modelMatrix).Xyz.Normalized();
            }

            return normals;
        }
    }
}