using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

public class CameraControlling : TogglingComponent
{
    private readonly Camera _camera;
    private readonly IEnumerable<MovementKey> _movementKeys;
    private readonly float _translationSpeed = 4f;
    private readonly float _acceleratedTranslationSpeed = 12f;
    private readonly float _rotationSpeed = 7f;
    private readonly float _draggingSpeed = 2f;
    
    public CameraControlling(Camera camera)
    {
        _camera = camera;
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
        float speed = WindowSettings.Keyboard.IsKeyDown(Keys.LeftShift) ? _acceleratedTranslationSpeed : _translationSpeed;

        if (_camera.Projection is OrthographicProjection)
        {
            if (WindowSettings.Mouse.IsButtonDown(MouseButton.Button2))
            {
                Vector2 delta = new(-WindowSettings.Mouse.Delta.X, WindowSettings.Mouse.Delta.Y);
                _camera.Transform.Position.Xy += delta * deltaTime * _draggingSpeed;
            }
        }
        else
        {
            foreach (MovementKey movementKey in _movementKeys)
            {
                if (WindowSettings.Keyboard.IsKeyDown(movementKey.Key))
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
            _camera.Transform.Yaw += WindowSettings.Mouse.Delta.X * _rotationSpeed * deltaTime;
            _camera.Transform.Pitch -= WindowSettings.Mouse.Delta.Y * _rotationSpeed * deltaTime;
        }
    }

    public void TryZoom(float deltaTime)
    {
        if (_camera.Projection is OrthographicProjection orthographicProjection)
        {
            orthographicProjection.Zoom(-WindowSettings.Mouse.ScrollDelta.Y * deltaTime);
        }
    }
}