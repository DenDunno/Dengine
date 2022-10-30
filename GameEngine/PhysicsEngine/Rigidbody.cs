using OpenTK.Mathematics;

public class Rigidbody
{
    public readonly Transform Transform;
    public readonly MeshWorldView MeshWorldView;

    public Rigidbody(Transform transform, MeshWorldView meshWorldView)
    {
        Transform = transform;
        MeshWorldView = meshWorldView;
    }

    public ColorShaderProgram ColorShaderProgram { get; init; } = null!;
    public ICollider Collider { get; init; } = new NullableCollider();
    public Vector3 Velocity { get; set; }
    public bool Trigger { get; init; } = false;
    public bool IsDynamic { get; init; } = false;
    public bool IsStatic { get; init; } = false;
    public float Mass { get; init; } = 1;
    public Vector3 Force { get; set; }
    public bool HasCollision { get; set; }
}