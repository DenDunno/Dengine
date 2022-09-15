using OpenTK.Mathematics;

public class RotationAnimation : IUpdatable
{
    private readonly Transform _transform;
    private readonly Vector3 _rotationVector;
    private const float _rotationSpeed = 1f;

    public RotationAnimation(Transform transform, Vector3 rotationVector)
    {
        _transform = transform;
        _rotationVector = rotationVector;
    }

    public void Update(float deltaTime)
    {
        _transform.Rotate(_rotationVector * deltaTime * _rotationSpeed);
    }
}