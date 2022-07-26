using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

public class MouseInput : IUpdatable
{
    private readonly MouseState _mouseState;
    private readonly Camera _camera;
    private readonly float _zoomSpeed = 25;
    private readonly float _translationSpeed = 0.5f;
    
    public MouseInput(MouseState mouseState, Camera camera)
    {
        _mouseState = mouseState;
        _camera = camera;
    }

    void IUpdatable.Update(float deltaTime)
    {
        if (_mouseState.IsButtonDown(MouseButton.Button3))
        {
            var delta = new Vector2(-_mouseState.Delta.X, _mouseState.Delta.Y);
            _camera.Translate(_translationSpeed * delta * deltaTime);
        }
        
        _camera.Zoom(-_mouseState.ScrollDelta.Y * deltaTime * _zoomSpeed);
    }
}