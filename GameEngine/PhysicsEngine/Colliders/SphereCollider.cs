using OpenTK.Mathematics;

public class SphereCollider : Collider
{
    public readonly float Radius;
    private readonly Transform _transform;
    private readonly Vector4 _centreOfSphere = new(0, 0, 0, 1);
    
    public SphereCollider(Transform transform, float radius)
    {
        _transform = transform;
        Radius = radius;
    }

    public Vector3 Centre => (_centreOfSphere * _transform.ModelMatrix).Xyz;

    public override bool CheckCollision(BoxCollider boxCollider) => CollisionDetection.CheckBoxSphereCollisions(boxCollider, this);

    public override bool CheckCollision(SphereCollider sphereCollider) => CollisionDetection.CheckSphereCollisions(this, sphereCollider);
}