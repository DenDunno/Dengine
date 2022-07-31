
public class World : IUpdatable
{
    private readonly IEnumerable<IDrawable> _drawables;
    private readonly IEnumerable<IUpdatable> _updatables;
    private readonly Camera _camera;

    public World(IEnumerable<IDrawable> drawables, IEnumerable<IUpdatable> updatables, Camera camera)
    {
        _drawables = drawables;
        _updatables = updatables;
        _camera = camera;
    }

    public void Update(float deltaTime)
    {
        _updatables.ForEach(gameObject => gameObject.Update(deltaTime));
    }

    public void Draw()
    {
        _drawables.ForEach(gameObject => gameObject.Draw(_camera.ViewMatrix));
    }
}