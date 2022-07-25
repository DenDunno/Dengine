
public class DrawableWithSwitching : IDrawable
{
    private readonly IDrawable _drawable;
    private bool _isRendering;
    
    public DrawableWithSwitching(IDrawable drawable)
    {
        _drawable = drawable;
    }

    public void Toggle()
    {
        _isRendering = !_isRendering;
    }

    void IDrawable.Draw()
    {
        if (_isRendering)
        {
            _drawable.Draw();
        }
    }
}