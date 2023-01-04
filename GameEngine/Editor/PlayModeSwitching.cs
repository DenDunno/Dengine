using OpenTK.Windowing.GraphicsLibraryFramework;

public class PlayModeSwitching 
{
    private readonly KeyboardState _keyboardState;
    private readonly ControlPanel _controlPanel;
    private readonly World _world;

    public PlayModeSwitching(Window window, World world, ControlPanel controlPanel)
    {
        _world = world;
        _controlPanel = controlPanel;
        _keyboardState = window.KeyboardState;
        controlPanel.PlayButton.OnClick += OnPlay;
        controlPanel.StopButton.OnClick += OnStop;
    }

    private bool _isPlaymode;

    private void OnStop()
    {
        ToggleEngineState(false);
    }

    private void OnPlay()
    {
        ToggleEngineState(true);
    }

    private void ToggleEngineState(bool isPlaymode)
    {
        _isPlaymode = isPlaymode;
        _world.Enabled = isPlaymode;
        _controlPanel.StopButton.Enabled = isPlaymode;
        _controlPanel.PlayButton.Enabled = isPlaymode == false;
    }

    public void Update(float deltaTime)
    {
        if (_isPlaymode && _keyboardState.IsKeyPressed(Keys.H))
        {
            OnStop();
        }
    }
}