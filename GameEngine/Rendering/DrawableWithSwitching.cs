
public class DrawableWithSwitching : IDrawable
{
    private readonly IDrawable _drawable;
    private bool _isRendering;
    
    public DrawableWithSwitching(IDrawable drawable, bool isRendering)
    {
        _drawable = drawable;
        _isRendering = isRendering;
    }

    public void Show()
    {
        _isRendering = true;
    }
    
    public void Hide()
    {
        _isRendering = false;
    }

    void IDrawable.Draw()
    {
        if (_isRendering)
        {
            _drawable.Draw();
        }
    }
}