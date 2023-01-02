using OpenTK.Windowing.Common;

public class Editor : EngineComponent
{
    private readonly ImGuiController _imGui;
    private readonly PlayModeSwitching _playModeSwitching;
    private readonly UI _ui;

    public Editor(Window window, World world)
    {
        _ui = new UI(world, window);
        _imGui = new ImGuiController(window);
        _playModeSwitching = new PlayModeSwitching(window, world, _ui.GetWidget<ControlPanel>());
    }

    public override void Initialize()
    {
        GrayOrangeTheme.Load();
    }

    public override void Update(FrameEventArgs args)
    {
        float deltaTime = (float) args.Time;
        
        _imGui.Update(deltaTime);
        _playModeSwitching.Update(deltaTime);
        _ui.Update(deltaTime);
    }

    public override void Draw(FrameEventArgs args)
    {
        if (_playModeSwitching.IsEditorMode)
        {
            _ui.DrawMain();
            _imGui.Render();
        }
    }
}