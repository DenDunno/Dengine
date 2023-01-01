
public abstract class Button : IWidget
{
    private readonly ButtonView _view;

    protected Button(ButtonView view)
    {
        _view = view;
    }
    
    public void Draw()
    {
        _view.Draw();
        
        if (_view.WasClicked)
        {
            OnClick();
        }
    }

    protected abstract void OnClick();
}