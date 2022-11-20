using OpenTK.Windowing.GraphicsLibraryFramework;

public class CameraControlling : IUpdatable
{
    private readonly Transform _camera;
    private readonly MouseState _mouseState;
    private readonly KeyboardState _keyboardState;
    private readonly IEnumerable<MovementKey> _movementKeys;
    private readonly float _translationSpeed = 4f;
    private readonly float _acceleratedTranslationSpeed = 12f;
    private readonly float _rotationSpeed = 7f;
    
    public CameraControlling(Transform camera, MouseState mouseState, KeyboardState keyboardState)
    {
        _camera = camera;
        _mouseState = mouseState;
        _keyboardState = keyboardState;
        _movementKeys = new List<MovementKey>
        {
            new(Keys.W, ()=> _camera.Orientation.Front),
            new(Keys.S, ()=> -_camera.Orientation.Front),
            new(Keys.D, ()=> _camera.Orientation.Right),
            new(Keys.A, ()=> -_camera.Orientation.Right),
            new(Keys.Space, ()=> _camera.Orientation.Up),
            new(Keys.LeftControl, ()=> -_camera.Orientation.Up),
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
        _camera.Orientation.Yaw += _mouseState.Delta.X * _rotationSpeed * deltaTime;
        _camera.Orientation.Pitch -= _mouseState.Delta.Y * _rotationSpeed * deltaTime;
    }
}