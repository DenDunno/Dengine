using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;

public class PlayModeSwitching : IUpdatable
{
    private readonly KeyboardState _keyboardState;
    private readonly CameraControlling _cameraControlling;
    private readonly Window _window;

    public PlayModeSwitching(Window window, CameraControlling cameraControlling)
    {
        _window = window;
        _keyboardState = window.KeyboardState;
        _cameraControlling = cameraControlling;
    }

    public bool IsPlayMode { get; private set; }
    
    public void Update(float deltaTime)
    {
        if (_keyboardState.IsKeyPressed(Keys.Enter))
        {
            IsPlayMode = !IsPlayMode;
            
            _cameraControlling.Toggle();
            _window.CursorState = IsPlayMode ? CursorState.Grabbed : CursorState.Normal;
        }
    }
}