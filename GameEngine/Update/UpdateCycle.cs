
public class UpdateCycle : IUpdatable
{
    private readonly IList<IUpdatable> _updatables;
    private readonly IList<IDrawable> _drawables;

    public UpdateCycle(IList<IUpdatable> updatables, IList<IDrawable> drawables)
    {
        _updatables = updatables;
        _drawables = drawables;
    }

    public void Update(double deltaTime)
    {
        _updatables.ForEach(updatable => updatable.Update(deltaTime));
        _drawables.ForEach(drawable => drawable.Draw());
    }
}