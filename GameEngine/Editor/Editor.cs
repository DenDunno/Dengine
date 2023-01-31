using OpenTK.Windowing.Common;

public class Editor : EngineComponent
{
    private readonly ImGuiController _imGui;
    private readonly PlayMode _playMode;
    private readonly EditorStyle _editorStyle;
    private readonly UI _ui;

    public Editor(Window window, World world)
    {
        _ui = new UI(world, window);
        _imGui = new ImGuiController(window);
        _playMode = new PlayMode(window, world, _ui.GetWidget<ControlPanel>());
        _editorStyle = new EditorStyle(new Icon("Icon.png", window), new GrayOrangeTheme());
    }

    public override void Initialize()
    {
        new DengineCompability().Check();
        _editorStyle.Load();
    }

    public override void Update(FrameEventArgs args)
    {
        float deltaTime = (float) args.Time;
        
        Timer.Update(deltaTime);
        _imGui.Update(deltaTime);
        _playMode.Update(deltaTime);
        _ui.Update(deltaTime);
    }

    public override void Draw(FrameEventArgs args)
    {
        if (UIEnabled)
        {
            _ui.Draw();
            _imGui.Render();    
        }
    }

    private bool UIEnabled
    {
        get
        {
            if (PlayMode.IsActive)
            {
                return ControlPanel.IsFullscreen == false;
            }

            return true;
        }
    }
}