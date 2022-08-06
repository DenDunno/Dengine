using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

public class Camera : IUpdatable
{
    private readonly Matrix4 _projectionMatrix;
    private readonly MouseState _mouseState;
    private readonly KeyboardState _keyboardState;
    private readonly Transform _transform = new();
    private const float _translationSpeed = 0.5f;
    private const float _rotationSpeed = 0.5f;
    private readonly IReadOnlyCollection<MovementKey> _movementKeys = new MovementKey[]
    {
        new(Keys.S, new Vector3(0,  1, 0)),
        new(Keys.W, new Vector3(0, -1, 0)),
        new(Keys.A, new Vector3(1,  0, 0)),
        new(Keys.D, new Vector3(-1, 0, 0)),
    };

    public Camera(KeyboardState keyboardState, MouseState mouseState)
    {
        _keyboardState = keyboardState;
        _mouseState = mouseState;
        _projectionMatrix = Matrix4.CreatePerspectiveFieldOfView(1, 1536f / 864, 1f, 1000.0f);        
    }

    public Matrix4 ProjectionViewMatrix => _projectionMatrix * _transform.ModelMatrix;

    void IUpdatable.Update(float deltaTime)
    {
        Vector2 delta = _mouseState.Delta * deltaTime * _rotationSpeed;
        _transform.Rotate(delta.X, delta.Y, 0);
        
        foreach (MovementKey movementKey in _movementKeys)
        {
            if (_keyboardState.IsKeyDown(movementKey.Key))
            {
                _transform.Move(movementKey.Direction * deltaTime * _translationSpeed);
                Matrix4 viewMatrix = _transform.ModelMatrix;
                GL.LoadMatrix(ref viewMatrix);
                GL.MatrixMode(MatrixMode.Modelview);
            }
        }
    }
}