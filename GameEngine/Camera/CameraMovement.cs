using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

public class CameraMovement : IUpdatable
{
    private readonly MouseState _mouseState;
    private readonly KeyboardState _keyboardState;
    private readonly Transform _cameraTransform;
    private const float _translationSpeed = 0.5f;

    public CameraMovement(Window window, Transform cameraTransform)
    {
        _mouseState = window.MouseState;
        _keyboardState = window.KeyboardState;
        _cameraTransform = cameraTransform;
    }

    void IUpdatable.Update(float deltaTime)
    {
        if (_keyboardState.IsAnyKeyDown)
        {
            if (_keyboardState.IsKeyDown(Keys.S))
            {
                _cameraTransform.Move(0, deltaTime, 0);
            }
            
            if (_keyboardState.IsKeyDown(Keys.W))
            {
                _cameraTransform.Move(0, -deltaTime, 0);
            }
            
            if (_keyboardState.IsKeyDown(Keys.A))
            {
                _cameraTransform.Move(deltaTime, 0, 0);
            }
            
            if (_keyboardState.IsKeyDown(Keys.D))
            {
                _cameraTransform.Move(-deltaTime, 0, 0);
            }

            Matrix4 proj = Matrix4.CreateTranslation(_cameraTransform.Position);
            GL.LoadMatrix(ref proj);
            GL.MatrixMode(MatrixMode.Modelview);
        }
    }
}