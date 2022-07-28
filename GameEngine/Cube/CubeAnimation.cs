using OpenTK.Mathematics;

public class CubeAnimation : IUpdatable
{
    private readonly Transform _transform;
    private readonly Vector3 _rotationVector = new(1, 1, 0);
    private const float _rotationSpeed = 2f;

    public CubeAnimation(Transform transform)
    {
        _transform = transform;
    }

    public void Update(float deltaTime)
    {
        _transform.Rotate(_rotationVector * deltaTime * _rotationSpeed);
    }
}