using OpenTK.Mathematics;

public class RotationAnimation : GameComponent
{
    [EditorField] private readonly float _rotationSpeed;
    private readonly Transform _transform;
    private readonly Vector3 _rotationVector;

    public RotationAnimation(Transform transform, Vector3 rotationVector, float rotationSpeed)
    {
        _transform = transform;
        _rotationVector = rotationVector;
        _rotationSpeed = rotationSpeed;
    }

    protected override void OnUpdate(float deltaTime)
    {
        _transform.Rotate(_rotationVector * deltaTime * _rotationSpeed);
    }
}