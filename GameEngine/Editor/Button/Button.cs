
public abstract class Button : IWidget
{
    private readonly ButtonView _view;

    protected Button(ButtonView view)
    {
        _view = view;
    }

    public event Action? OnClick;

    public void Draw()
    {
        _view.Draw();
        
        if (_view.WasClicked)
        {
            OnClick?.Invoke();
        }
    }
}