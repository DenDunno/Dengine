using ImGuiNET;
using OpenTK.Windowing.Common;

public class Editor : EngineComponent
{
    private readonly ImGuiController _imGui;
    private readonly PlayModeSwitching _playModeSwitching;
    private readonly EditorStyle _editorStyle;
    private readonly UI _ui;

    public Editor(Window window, World world)
    {
        _ui = new UI(world, window);
        _imGui = new ImGuiController(window);
        _playModeSwitching = new PlayModeSwitching(window, world, _ui.GetWidget<ControlPanel>());
        _editorStyle = new EditorStyle(new Icon("Icon.png", window), new GrayOrangeTheme());
    }

    public override void Initialize()
    {
        _editorStyle.Load();
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
        _ui.Draw();
        _imGui.Render();
    }
}