using OpenTK.Windowing.GraphicsLibraryFramework;

public class CameraControlling : IUpdatable
{
    private readonly Camera _camera;
    private readonly MouseState _mouseState;
    private readonly KeyboardState _keyboardState;
    private readonly IEnumerable<MovementKey> _movementKeys;
    private const float _translationSpeed = 2f;
    private const float _acceleratedTranslationSpeed = 6f;
    private const float _rotationSpeed = 7f;
    
    public CameraControlling(Camera camera, MouseState mouseState, KeyboardState keyboardState)
    {
        _camera = camera;
        _mouseState = mouseState;
        _keyboardState = keyboardState;
        _movementKeys = new List<MovementKey>
        {
            new(Keys.W, ()=> _camera.Front),
            new(Keys.S, ()=> -_camera.Front),
            new(Keys.D, ()=> _camera.Right),
            new(Keys.A, ()=> -_camera.Right),
            new(Keys.Space, ()=> _camera.Up),
            new(Keys.LeftControl, ()=> -_camera.Up),
        };
    }
    
    public void Update(float deltaTime)
    {
        Move(deltaTime);
        Rotate(deltaTime);
    }

    private void Move(float deltaTime)
    {
        float speed = _keyboardState.IsKeyDown(Keys.LeftShift) ? _acceleratedTranslationSpeed : _translationSpeed;
        
        foreach (MovementKey movementKey in _movementKeys)
        {
            if (_keyboardState.IsKeyDown(movementKey.Key))
            {
                _camera.Position += movementKey.Direction() * speed * deltaTime;
            }
        }
    }

    private void Rotate(float deltaTime)
    {
        _camera.Yaw += _mouseState.Delta.X * _rotationSpeed * deltaTime;
        _camera.Pitch -= _mouseState.Delta.Y * _rotationSpeed * deltaTime;
    }
}