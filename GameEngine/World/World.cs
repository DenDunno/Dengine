
public class World : IUpdatable
{
    private readonly IInitializable[] _initializable;
    private readonly IEnumerable<IDrawable> _drawables;
    private readonly IEnumerable<IUpdatable> _updatables;
    private readonly Camera _camera;

    public World(IInitializable[] initializable, IUpdatable[] updatables, IDrawable[] drawables, Camera camera)
    {
        _initializable = initializable;
        _updatables = updatables;
        _drawables = drawables;
        _camera = camera;
    }

    public void Initialize()
    {
        _initializable.ForEach(initializable => initializable.Initialize());
    }
    
    public void Update(float deltaTime)
    {
        _updatables.ForEach(gameObject => gameObject.Update(deltaTime));
    }

    public void Draw()
    {
        _drawables.ForEach(gameObject => gameObject.Draw(_camera.ProjectionViewMatrix));
    }
}