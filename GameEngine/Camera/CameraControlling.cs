using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

public class CameraControlling : TogglingComponent
{
    private readonly Camera _camera;
    private readonly PlayerInput _playerInput;
    private readonly IEnumerable<MovementKey> _movementKeys;
    private readonly float _translationSpeed = 4f;
    private readonly float _acceleratedTranslationSpeed = 12f;
    private readonly float _rotationSpeed = 7f;
    private readonly float _draggingSpeed = 2f;
    
    public CameraControlling(Camera camera, PlayerInput playerInput)
    {
        _camera = camera;
        _playerInput = playerInput;
        _movementKeys = new List<MovementKey>
        {
            new(Keys.W, ()=> _camera.Transform.Front),
            new(Keys.S, ()=> -_camera.Transform.Front),
            new(Keys.D, ()=> _camera.Transform.Right),
            new(Keys.A, ()=> -_camera.Transform.Right),
            new(Keys.Space, ()=> _camera.Transform.Up),
            new(Keys.LeftControl, ()=> -_camera.Transform.Up),
        };
    }
    
    protected override void OnUpdate(float deltaTime)
    {
        Move(deltaTime);
        Rotate(deltaTime);
        TryZoom(deltaTime);
    }

    public void Move(float deltaTime)
    {
        float speed = _playerInput.Keyboard.IsKeyDown(Keys.LeftShift) ? _acceleratedTranslationSpeed : _translationSpeed;

        if (_camera.Projection is OrthographicProjection)
        {
            Vector2 delta = new(-_playerInput.Mouse.Delta.X, _playerInput.Mouse.Delta.Y);
            _camera.Transform.Position.Xy += delta * deltaTime * _draggingSpeed;
        }
        else
        {
            foreach (MovementKey movementKey in _movementKeys)
            {
                if (_playerInput.Keyboard.IsKeyDown(movementKey.Key))
                {
                    _camera.Transform.Position += movementKey.Direction() * speed * deltaTime;
                }
            }
        }
    }

    public void Rotate(float deltaTime)
    {
        if (_camera.Projection is PerspectiveProjection)
        {
            _camera.Transform.Yaw += _playerInput.Mouse.Delta.X * _rotationSpeed * deltaTime;
            _camera.Transform.Pitch -= _playerInput.Mouse.Delta.Y * _rotationSpeed * deltaTime;
        }
    }

    public void TryZoom(float deltaTime)
    {
        if (_camera.Projection is OrthographicProjection orthographicProjection)
        {
            orthographicProjection.Zoom(-_playerInput.Mouse.ScrollDelta.Y * deltaTime);
        }
    }
}