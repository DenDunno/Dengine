
public class UI
{
    private readonly IWidget[] _main;
    private readonly StatsWidget _stats;
    
    public UI(World world, Window window)
    {
        Inspector inspector = new();
        _stats = new StatsWidget();
        _main = new IWidget[]
        {
            new DockSpace(),
            inspector,
            new Hierarchy(world, inspector),
            new ControlPanel(),
            new Viewport(window, new WorldBrowser(world).FindFirst<Camera>()),
        };
    }

    public T GetWidget<T>() where T : IWidget
    {
        T result = default!;
        
        foreach (IWidget widget in _main)
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
        _main.ForEach(widget => widget.Update(deltaTime));
    }
    
    public void DrawMain()
    {
        _main.ForEach(widget => widget.Draw());
    }

    public void DrawStats()
    {
        _stats.Draw();
    }
}