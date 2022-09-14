using OpenTK.Mathematics;

public class Rigidbody
{
    public readonly Transform Transform;
    public bool Trigger { get; init; }
    public bool IsDynamic { get; init; }
    public Vector3 Velocity;

    public Rigidbody(Transform transform)
    {
        Transform = transform;
    }
}