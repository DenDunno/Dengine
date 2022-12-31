
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
            new Hierarchy(world, inspector),
            new ControlPanel(),
            new Viewport(window, new WorldBrowser(world).FindFirst<CameraControlling>()),
            inspector
        };
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