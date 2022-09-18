using OpenTK.Mathematics;

public class Rigidbody
{
    public readonly Transform Transform;
    public readonly BoxCollider BoxCollider;

    public bool Trigger { get; init; }
    public bool IsDynamic { get; init; }
    public Vector3 Velocity;

    public Rigidbody(Transform transform, BoxCollider boxCollider)
    {
        Transform = transform;
        BoxCollider = boxCollider;
    }
}