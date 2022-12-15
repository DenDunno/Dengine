
public class Skybox : TogglingComponent
{
    private readonly Transform _camera;
    private readonly Transform _transform;
    
    public Skybox(Transform camera, Transform transform)
    {
        _camera = camera;
        _transform = transform;
    }

    protected override void OnUpdate(float deltaTime)
    {
        _transform.Position = _camera.Position;
    }
}