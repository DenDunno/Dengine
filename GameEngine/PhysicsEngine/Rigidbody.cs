using OpenTK.Mathematics;

public class Rigidbody
{
    public bool IsDynamic { get; init; }
    public bool Trigger { get; init; }
    public Transform Transform { get; init; } = new();
    public Vector3 Velocity;
}