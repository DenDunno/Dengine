using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;

public class PlayModeSwitching : IUpdatable
{
    private readonly KeyboardState _keyboardState;
    private readonly CameraControlling _cameraControlling;
    private readonly Window _window;

    public PlayModeSwitching(Window window, World world)
    {
        _window = window;
        _keyboardState = window.KeyboardState;
        _cameraControlling = new WorldBrowser(world).FindFirst<CameraControlling>();
    }

    public bool IsEditorMode { get; private set; }
    
    public void Update(float deltaTime)
    {
        if (_keyboardState.IsKeyPressed(Keys.Enter))
        {
            IsEditorMode = !IsEditorMode;
            
            _cameraControlling.Enabled = !IsEditorMode;
            _window.CursorState = IsEditorMode ? CursorState.Normal : CursorState.Grabbed;
        }
    }
}