using OpenTK.Mathematics;

public class Rigidbody
{
    public readonly Transform Transform;
    public readonly BoxCollider BoxCollider;

    public Vector3 Velocity { get; set; }
    public bool Trigger { get; init; } = false;
    public bool IsDynamic { get; init; } = false;
    public float Mass { get; init; } = 1;

    public Rigidbody(Transform transform, BoxCollider boxCollider)
    {
        Transform = transform;
        BoxCollider = boxCollider;
    }
}