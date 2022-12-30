using OpenTK.Windowing.Common;

public class Editor : IEngineComponent
{
    private readonly ImGuiController _imGui;
    private readonly PlayModeSwitching _playModeSwitching;
    private readonly UI _ui;

    public Editor(Window window, World world)
    {
        _ui = new UI(world);
        _imGui = new ImGuiController(window);
        _playModeSwitching = new PlayModeSwitching(window, world);
    }

    public void Initialize()
    {
        GrayOrangeTheme.Load();
    }

    public void Update(FrameEventArgs args)
    {
        float deltaTime = (float) args.Time;
        
        _imGui.Update(deltaTime);
        _playModeSwitching.Update(deltaTime);
        _ui.Update(deltaTime);
    }

    public void Draw(FrameEventArgs args)
    {
        if (_playModeSwitching.IsEditorMode)
        {
            _ui.DrawMain();
        }
        else if (_playModeSwitching.IsStats)
        {
            _ui.DrawStats();
        }

        _imGui.Render();
    }
}