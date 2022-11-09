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

    public Vector3[] Positions => MultiplyWithModelMatrix(_mesh.Data.Positions, false);

    public Vector3[] Normals => MultiplyWithModelMatrix(_mesh.Data.Positions!, true);

    private Vector3[] MultiplyWithModelMatrix(Vector3[] data, bool isDirection)
    {
        int w = isDirection ? 0 : 1;
        Matrix4 modelMatrix = _transform.ModelMatrix;
        Vector3[] worldViewData = new Vector3[data.Length];

        for (int i = 0; i < data.Length; ++i)
        {
            Vector4 worldViewVector = new(data[i], w);
            worldViewData[i] = (worldViewVector * modelMatrix).Xyz;

            if (isDirection)
            {
                worldViewData[i].Normalize();
            }
        }

        return worldViewData;
    }
}