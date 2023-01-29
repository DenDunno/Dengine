using OpenTK.Mathematics;

public class GradientAnimation : IGameComponent
{
    private readonly ShaderBridge _bridge;
    private readonly Transform _transform;
    private readonly ParticleSystemData _data;
    [EditorField] private float _speed = 0.6f;
    [EditorField] private float _lerp;

    public GradientAnimation(ShaderBridge bridge, Transform transform, ParticleSystemData data)
    {
        _bridge = bridge;
        _transform = transform;
        _data = data;
    }

    void IGameComponent.Update(float deltaTime)
    {
        _lerp += deltaTime * _speed;
        
        if (_lerp >= 1 || _lerp <= 0)
            _speed = -_speed;
        
        _lerp = Algorithms.Clamp(0, 1, _lerp);
        
        _bridge.SetColor("lightColor", _data.Color.GetValue(_lerp));
        _transform.Scale = _data.Size.GetValue(_lerp) * Vector3.One;
        _transform.Rotation = Quaternion.FromEulerAngles(_data.Rotation.GetValue(_lerp));
    }
}