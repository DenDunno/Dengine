using OpenTK.Mathematics;

public class LODGroup : IMeshProvider
{
    private readonly LODMesh[] _lodMeshes;
    private readonly Transform _transform;
    private readonly Camera _camera;
    private MeshBinding _current;
    
    public LODGroup(Transform transform, Camera camera, LODMesh[] lodMeshes)
    {
        _lodMeshes = lodMeshes.OrderBy(mesh => mesh.Distance).ToArray();
        _current = _lodMeshes[0].Mesh;
        _transform = transform;
        _camera = camera;
    }

    public Mesh Mesh => _current.Mesh;

    public void Bind()
    {
        _current = GetLODMesh();
        _current.Bind();
        _current.BufferData();
    }

    private MeshBinding GetLODMesh()
    {
        float distance = Vector3.Distance(_camera.Transform.Position, _transform.Position);
        MeshBinding result = _lodMeshes[0].Mesh;

        for (int i = 0; i < _lodMeshes.Length - 1; ++i)
        {
            if (distance > _lodMeshes[i].Distance)
            {
                result = _lodMeshes[i + 1].Mesh;
            }
        }

        return result;
    }

    public void Dispose()
    {
        foreach (LODMesh lodMesh in _lodMeshes)
        {
            lodMesh.Dispose();
        }
    }
}