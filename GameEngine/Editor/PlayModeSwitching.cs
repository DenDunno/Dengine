using OpenTK.Windowing.GraphicsLibraryFramework;

public class PlayModeSwitching 
{
    private readonly KeyboardState _keyboardState;
    private readonly Window _window;
    private readonly World _world;

    public PlayModeSwitching(Window window, World world, ControlPanel controlPanel)
    {
        _window = window;
        _world = world;
        _keyboardState = window.KeyboardState;
        controlPanel.PlayButton.OnClick += OnPlay;
        controlPanel.StopButton.OnClick += OnStop;
    }

    public bool IsEditorMode { get; private set; } = true;
    private bool IsPlaymode { get; set; }
    public bool IsStats { get; private set; }

    private void OnStop()
    {
        IsPlaymode = false;
        _world.Stop();
    }

    private void OnPlay()
    {
        IsPlaymode = true;
        _world.Resume();
    }

    public void Update(float deltaTime)
    {
        if (IsPlaymode && _keyboardState.IsKeyPressed(Keys.H))
        {
            OnStop();
        }
    }
}