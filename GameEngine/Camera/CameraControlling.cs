using OpenTK.Windowing.GraphicsLibraryFramework;

public class CameraControlling : TogglingComponent
{
    private readonly Transform _camera;
    private readonly PlayerInput _playerInput;
    private readonly IEnumerable<MovementKey> _movementKeys;
    private readonly float _translationSpeed = 4f;
    private readonly float _acceleratedTranslationSpeed = 12f;
    private readonly float _rotationSpeed = 7f;
    
    public CameraControlling(Transform camera, PlayerInput playerInput)
    {
        _camera = camera;
        _playerInput = playerInput;
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

    protected override void OnInitialize()
    {
    }

    protected override void OnUpdate(float deltaTime)
    {
        Move(deltaTime);
        Rotate(deltaTime);
    }

    private void Move(float deltaTime)
    {
        float speed = _playerInput.Keyboard.IsKeyDown(Keys.LeftShift) ? _acceleratedTranslationSpeed : _translationSpeed;
        
        foreach (MovementKey movementKey in _movementKeys)
        {
            if (_playerInput.Keyboard.IsKeyDown(movementKey.Key))
            {
                _camera.Position += movementKey.Direction() * speed * deltaTime;
            }
        }
    }

    private void Rotate(float deltaTime)
    {
        _camera.Orientation.Yaw += _playerInput.Mouse.Delta.X * _rotationSpeed * deltaTime;
        _camera.Orientation.Pitch -= _playerInput.Mouse.Delta.Y * _rotationSpeed * deltaTime;
    }
}