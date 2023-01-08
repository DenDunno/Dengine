
public class UI
{
    private readonly List<UIElement> _elements;

    public UI(World world, Window window)
    {
        Inspector inspector = new();

        _elements = new List<UIElement>
        {
            new DockSpace(),
            new StatsPanel(),
            inspector,
            new Hierarchy(world, inspector),
            new DengineConsole(),
            new ControlPanel(),
            new Viewport(window, WorldBrowser.Instance.FindObjectOfType<Camera>()),
        };
    }

    public T GetWidget<T>() where T : UIElement
    {
        T result = default!;
        
        foreach (UIElement widget in _elements)
        {
            if (widget is T castedT)
            {
                result = castedT;
            }
        }

        return result;
    }

    public void Update(float deltaTime)
    {
        _elements.ForEach(widget => widget.Update(deltaTime));
    }
    
    public void Draw()
    {
        _elements.ForEach(widget => widget.Draw());
    }
}