
public class DebugObjects : IDrawable
{
    private readonly IReadOnlyCollection<IDrawable> _drawables;

    public DebugObjects(IReadOnlyCollection<IDrawable> drawables)
    {
        _drawables = drawables;
    }

    void IDrawable.Draw()
    {
        _drawables.ForEach(drawable => drawable.Draw());
    }
}