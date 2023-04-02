using OpenTK.Mathematics;

public class Skybox : IGameComponent
{
    private readonly ShaderBridge _bridge;
    private readonly float _rotationSpeed;
    private readonly Vector3 _rotationVector;
    private readonly float _circle = 2 * MathF.PI;
    private float _angle;

    public Skybox(ShaderBridge bridge, Vector3 rotationVector, float rotationSpeed)
    {
        _bridge = bridge;
        _rotationSpeed = rotationSpeed;
        _rotationVector = rotationVector;
    }

    void IGameComponent.Initialize()
    {
        _bridge.SetVector3("rotationVector", _rotationVector);
    }
    
    void IGameComponent.Update(float deltaTime)
    {
        _angle = (_angle + deltaTime * _rotationSpeed) % _circle;
        
        _bridge.SetFloat("angle", _angle);
    }
}