using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

public class CameraMovement : IUpdatable
{
    private readonly MouseState _mouseState;
    private readonly KeyboardState _keyboardState;
    private readonly Transform _transform;
    private const float _translationSpeed = 0.5f;

    public CameraMovement(KeyboardState keyboardState, MouseState mouseState, Transform transform)
    {
        _keyboardState = keyboardState;
        _mouseState = mouseState;
        _transform = transform;
    }

    void IUpdatable.Update(float deltaTime)
    {
        if (_keyboardState.IsAnyKeyDown)
        {
            if (_keyboardState.IsKeyDown(Keys.S))
            {
                _transform.Move(0, deltaTime, 0);
            }
            
            if (_keyboardState.IsKeyDown(Keys.W))
            {
                _transform.Move(0, -deltaTime, 0);
            }
            
            if (_keyboardState.IsKeyDown(Keys.A))
            {
                _transform.Move(deltaTime, 0, 0);
            }
            
            if (_keyboardState.IsKeyDown(Keys.D))
            {
                _transform.Move(-deltaTime, 0, 0);
            }

            Matrix4 proj = Matrix4.CreateTranslation(_transform.Position);
            Console.WriteLine(proj);
            GL.LoadMatrix(ref proj);
            GL.MatrixMode(MatrixMode.Modelview);
        }
    }
}