using System.Drawing;
using OpenTK.Mathematics;

public class GradientAnimation : IGameComponent
{
    private readonly ShaderBridge _bridge;
    private readonly Transform _transform;
    private readonly AnimationCurve<Color> _colorAnimationCurve;
    private readonly AnimationCurve<float> _sizeAnimationCurve;
    [EditorField] private float _speed = 0.6f;
    [EditorField] private float _lerp;

    public GradientAnimation(ShaderBridge bridge, Transform transform, AnimationCurve<Color> colorAnimationCurve, AnimationCurve<float> sizeAnimationCurve)
    {
        _bridge = bridge;
        _transform = transform;
        _sizeAnimationCurve = sizeAnimationCurve;
        _colorAnimationCurve = colorAnimationCurve;
    }

    void IGameComponent.Update(float deltaTime)
    {
        _lerp += deltaTime * _speed;
        
        if (_lerp >= 1 || _lerp <= 0)
            _speed = -_speed;
        
        _lerp = Algorithms.Clamp(0, 1, _lerp);
        
        _bridge.SetColor("lightColor", _colorAnimationCurve.GetValue(_lerp));
        _transform.Scale = _sizeAnimationCurve.GetValue(_lerp) * Vector3.One;
    }
}