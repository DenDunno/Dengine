
public class Skybox : IUpdatable
{
    private readonly ModelMatrix _camera;
    private readonly ModelMatrix _transform;
    
    public Skybox(ModelMatrix camera, ModelMatrix transform)
    {
        _camera = camera;
        _transform = transform;
    }
    
    public void Update(float deltaTime)
    {
        _transform.Position = _camera.Position;
    }
}