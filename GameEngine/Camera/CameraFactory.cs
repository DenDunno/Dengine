using OpenTK.Windowing.GraphicsLibraryFramework;

public class CameraFactory
{
    private readonly KeyboardState _keyboardState;
    private readonly MouseState _mouseState;

    public CameraFactory(KeyboardState keyboardState, MouseState mouseState)
    {
        _keyboardState = keyboardState;
        _mouseState = mouseState;
    }

    public GameObject Create()
    {
        var transform = new Transform();
        var cameraMovement = new CameraMovement(_keyboardState, _mouseState, transform);
        var components = new IUpdatable[] {cameraMovement};
        
        return new GameObject(transform, components);
    }
}