using OpenTK.Mathematics;

public class Rigidbody
{
    public readonly Transform Transform;

    public Rigidbody(Transform transform)
    {
        Transform = transform;
    }

    public ICollider Collider { get; init; } = new NullableCollider();
    public Vector3 Velocity { get; set; }
    public bool Trigger { get; init; } = false;
    public bool IsDynamic { get; init; } = false;
    public bool IsStatic { get; init; } = false;
    public float Mass { get; init; } = 1;
    public Vector3 Force { get; set; }
}