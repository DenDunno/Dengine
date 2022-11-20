
public class Skybox : IUpdatable
{
    private readonly Transform _camera;
    private readonly Transform _transform;
    
    public Skybox(Transform camera, Transform transform)
    {
        _camera = camera;
        _transform = transform;
    }
    
    public void Update(float deltaTime)
    {
        _transform.Position = _camera.Position;
    }
}