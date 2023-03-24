using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;

public class PlayMode 
{
    private readonly KeyboardState _keyboardState;
    private readonly ControlPanel _controlPanel;
    private readonly Window _window;
    private readonly World _world;

    public PlayMode(Window window, World world, ControlPanel controlPanel)
    {
        _window = window;
        _world = world;
        _controlPanel = controlPanel;
        _keyboardState = window.KeyboardState;
        controlPanel.PlayButton.OnClick += OnPlay;
        controlPanel.StopButton.OnClick += OnStop;
    }

    public static bool IsActive { get; private set; }

    private void OnStop()
    {
        ToggleState(false);
    }

    private void OnPlay()
    {
        ToggleState(true);
    }

    private void ToggleState(bool isPlaymode)
    {
        IsActive = isPlaymode;
        _world.Enabled = isPlaymode;
        _controlPanel.StopButton.Enabled = isPlaymode;
        _controlPanel.PlayButton.Enabled = isPlaymode == false;
        
        if (ControlPanel.IsFullscreen)
        {
            _window.WindowState = isPlaymode ? WindowState.Fullscreen : WindowState.Normal;
            _window.CursorState = isPlaymode ? CursorState.Grabbed : CursorState.Normal;
        }
    }

    public void Update()
    {
        if (IsActive && _keyboardState.IsKeyPressed(Keys.Escape))
        {
            OnStop();
        }
    }
}