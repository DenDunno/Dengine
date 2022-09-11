
public class Skybox : IUpdatable
{
    private readonly Camera _camera;
    private readonly Transform _transform;
    
    public Skybox(Camera camera, Transform transform)
    {
        _camera = camera;
        _transform = transform;
    }
    
    public void Update(float deltaTime)
    {
        //_transform.Position = _camera.Position;
    }
}