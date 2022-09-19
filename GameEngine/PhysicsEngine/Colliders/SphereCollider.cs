using OpenTK.Mathematics;

public class SphereCollider
{
    public readonly float Radius;
    private readonly Transform _transform;
    private readonly Vector4 _centreOfSphere = new(0, 0, 0, 1);
    
    public SphereCollider(Transform transform, float radius)
    {
        _transform = transform;
        Radius = radius;
    }

    private Vector3 Centre => (_centreOfSphere * _transform.ModelMatrix).Xyz;
    
    public bool CheckCollision(SphereCollider sphereCollider)
    {
        return Vector3.Distance(sphereCollider.Centre, Centre) <= sphereCollider.Radius + Radius;
    }
}