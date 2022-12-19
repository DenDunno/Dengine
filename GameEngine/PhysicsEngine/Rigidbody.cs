using OpenTK.Mathematics;

public class Rigidbody : IGameComponent
{
    [EditorField] public Vector3 Velocity;
    public readonly Transform Transform;
    public readonly Action? TriggerEntered = null;
    public readonly Action? TriggerStay = null;
    
    public Rigidbody(Transform transform)
    {
        Transform = transform;
    }

    public ICollider Collider { get; init; } = new NullableCollider();
    public bool Trigger { get; init; } = false;
    public bool IsDynamic { get; init; } = false;
    public bool IsStatic { get; init; } = false;
    public float Mass { get; init; } = 1;
    public Vector3 Force { get; set; }

    void IGameComponent.Initialize()
    {
        Collider.Init();
    }
}