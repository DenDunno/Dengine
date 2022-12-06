using OpenTK.Mathematics;

public class MeshWorldView
{
    private readonly Transform _transform;
    private readonly List<MeshVertex> _meshLocalVertices = new();
    private MeshVertex[] _meshWorldVertices = null!;
    private readonly Mesh _mesh;

    public MeshWorldView(Transform transform, Mesh mesh)
    {
        _transform = transform;
        _mesh = mesh;
    }

    public IReadOnlyList<MeshVertex> GetWorldVertices()
    {
        Matrix4 modelMatrix = _transform.ModelMatrix;
        
        for (int i = 0; i < _meshLocalVertices.Count; ++i)
        {
            _meshWorldVertices[i].Position = (new Vector4(_meshLocalVertices[i].Position, 1) * modelMatrix).Xyz;

            for (int j = 0; j < _meshLocalVertices[i].Normals.Count; ++j)
            {
                _meshWorldVertices[i].Normals[j] = (new Vector4(_meshLocalVertices[i].Normals[j], 0) * modelMatrix).Xyz;
            }
        }
        
        return _meshWorldVertices;
    }
    
    public void CalculateNormals()
    {
        _meshLocalVertices.Clear();
        
        FillMeshVertices();
        CalculateEdgeNormals();
        AllocateMemoryForWorldVertices();
    }

    private void AllocateMemoryForWorldVertices()
    {
        _meshWorldVertices = new MeshVertex[_meshLocalVertices.Count];

        for (int i = 0; i < _meshWorldVertices.Length; ++i)
        {
            _meshWorldVertices[i].Normals = new List<Vector3>(_meshLocalVertices[i].Normals);
        }
    }

    private void FillMeshVertices()
    {
        Dictionary<Vector3, int> positionIndices = new();

        for (int i = 0; i < _mesh.Data.Positions.Length; ++i)
        {
            Vector3 position = _mesh.Data.Positions[i];
            Vector3 normal = _mesh.Data.Normals![i];

            if (positionIndices.ContainsKey(position))
            {
                _meshLocalVertices[positionIndices[position]].Normals.Add(normal);
            }
            else
            {
                positionIndices[position] = positionIndices.Count;

                _meshLocalVertices.Add(new MeshVertex(position, normal));
            }
        }
    }

    private void CalculateEdgeNormals()
    {
        foreach (MeshVertex meshLocalVertex in _meshLocalVertices)
        {
            int normalsCount = meshLocalVertex.Normals.Count;
            
            for (int i = 0; i < normalsCount; ++i)
            {
                for (int j = i + 1; j < normalsCount; ++j)
                {
                    Vector3 edgeNormal = meshLocalVertex.Normals[i] + meshLocalVertex.Normals[j];
                    meshLocalVertex.Normals.Add(edgeNormal);
                }
            }
        }
    }

    public Vector3[] Positions => MultiplyWithModelMatrix(_mesh.Data.Positions, false);

    public Vector3[] Normals => MultiplyWithModelMatrix(_mesh.Data.Normals!, true);

    private Vector3[] MultiplyWithModelMatrix(IReadOnlyList<Vector3> data, bool isDirection)
    {
        int w = isDirection ? 0 : 1;
        Matrix4 modelMatrix = _transform.ModelMatrix;
        Vector3[] worldViewData = new Vector3[data.Count];

        for (int i = 0; i < data.Count; ++i)
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