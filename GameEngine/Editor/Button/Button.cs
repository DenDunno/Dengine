
public abstract class Button : UIElement
{
    private readonly ButtonView _view;

    protected Button(ButtonView view)
    {
        _view = view;
    }

    public event Action? OnClick;

    protected override void OnDraw()
    {
        _view.Draw();
        
        if (_view.WasClicked)
        {
            OnClick?.Invoke();
        }
    }
}