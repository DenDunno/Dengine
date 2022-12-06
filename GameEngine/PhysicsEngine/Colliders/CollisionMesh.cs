using OpenTK.Mathematics;

public abstract class CollisionMesh
{
    private readonly Transform _transform;
    private Vector3[] _localVertices = null!;
    private Vector3[] _worldVertices = null!;

    protected CollisionMesh(Mesh mesh, Transform transform)
    {
        Mesh = mesh;
        _transform = transform;
    }
    
    public Vector3[] Vertices => Algorithms.MultiplyPointsWithMatrix4(_transform.ModelMatrix, _localVertices, _worldVertices);
    protected Mesh Mesh { get; }
    protected Transform Transform => _transform;

    public void Init()
    {
        _localVertices = CalculateMesh();
        _worldVertices = new Vector3[_localVertices.Length];
    }
    
    protected abstract Vector3[] CalculateMesh();
}