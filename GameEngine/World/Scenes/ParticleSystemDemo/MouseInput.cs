using OpenTK.Mathematics;

public class MouseInput : IGameComponent
{
    private readonly Camera _camera;
    private readonly ParticleSystem _particleSystem;

    public MouseInput(Camera camera, ParticleSystem particleSystem)
    {
        _camera = camera;
        _particleSystem = particleSystem;
    }

    void IGameComponent.Update(float deltaTime)
    {
        _particleSystem.Enabled = WindowSettings.Mouse.IsAnyButtonDown;
        
        if (_particleSystem.Enabled)
        {
            Vector3 position = _camera.ScreenToWorldCoordinates(WindowSettings.Mouse.Position).ToVector3();
            _particleSystem.Transform.Position = position;
        }
    }
}