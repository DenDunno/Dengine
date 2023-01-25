using OpenTK.Mathematics;

public class MovementAnimation : TogglingComponent
{
    [EditorField] private readonly float _movementSpeed = 1f;
    private readonly Transform _transform;
    private readonly Vector3 _target;
    private readonly Vector3 _start;
    private float _time;

    public MovementAnimation(Transform transform, Vector3 movementVector)
    {
        _transform = transform;
        _target = transform.Position + movementVector;
        _start = transform.Position;
    }

    protected override void OnUpdate(float deltaTime)
    {
        _time += deltaTime * _movementSpeed;
        float lerp = MathF.Sin(_time);
        _transform.Position = Vector3.Lerp(_start, _target, lerp);
    }
}