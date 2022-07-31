using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

public class CameraMovement : IUpdatable
{
    private readonly MouseState _mouseState;
    private readonly KeyboardState _keyboardState;
    private readonly Transform _transform;
    private const float _translationSpeed = 0.5f;
    private readonly IReadOnlyCollection<MovementKey> _movementKeys = new MovementKey[]
    {
        new(Keys.S, new Vector3(0,  1, 0)),
        new(Keys.W, new Vector3(0, -1, 0)),
        new(Keys.A, new Vector3(1,  0, 0)),
        new(Keys.D, new Vector3(-1, 0, 0)),
    };

    public CameraMovement(KeyboardState keyboardState, MouseState mouseState, Transform transform)
    {
        _keyboardState = keyboardState;
        _mouseState = mouseState;
        _transform = transform;
    }

    void IUpdatable.Update(float deltaTime)
    {
        foreach (MovementKey movementKey in _movementKeys)
        {
            if (_keyboardState.IsKeyDown(movementKey.Key))
            {
                _transform.Move(movementKey.Direction * deltaTime);
                
                Matrix4 proj = Matrix4.CreateTranslation(_transform.Position);
                Console.WriteLine(proj);
                GL.LoadMatrix(ref proj);
                GL.MatrixMode(MatrixMode.Modelview);
            }
        }
    }
}