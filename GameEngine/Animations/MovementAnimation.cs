using OpenTK.Mathematics;

public class MovementAnimation : IUpdatable
{
    private readonly Transform _transform;
    private readonly Vector3 _movementVector;
    private const float _movementSpeed = 1f;

    public MovementAnimation(Transform transform, Vector3 movementVector)
    {
        _transform = transform;
        _movementVector = movementVector;
    }

    public void Update(float deltaTime)
    {
        float time = MathF.Sin(Timer.Time);
        _transform.Move(time * _movementSpeed * _movementVector * deltaTime);
    }
}