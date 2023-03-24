using OpenTK.Mathematics;

public class SunAnimation : TogglingComponent
{
    private readonly ShaderBridge _bridge;
    private readonly IGameComponent _rotationAnimation;
    
    public SunAnimation(ShaderBridge bridge, Transform transform)
    {
        _bridge = bridge;
        _rotationAnimation = new RotationAnimation(transform, Vector3.UnitY, 0.25f);
    }

    protected override void OnUpdate(float deltaTime)
    {
        _rotationAnimation.Update(deltaTime);
        _bridge.SetFloat("time", Clock.Time);
    }
}