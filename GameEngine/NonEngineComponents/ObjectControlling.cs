using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

public class ObjectControlling : IUpdatable
{
    private readonly Transform _transform;
    private readonly KeyboardState _keyboardState;
    private const float _movementSpeed = 2f;
    private readonly Dictionary<Keys, Vector3> _directions = new()
    {
        {Keys.Up, new Vector3(0, 1, -0)},
        {Keys.Down, new Vector3(0, -1, 0)},
        {Keys.Left, new Vector3(-1, 0, 0)},
        {Keys.Right, new Vector3(1, 0, 0)},
        {Keys.KeyPad5, new Vector3(0, 1, 0)},
        {Keys.KeyPad2, new Vector3(0, -1, 0)},
    };

    public ObjectControlling(Transform transform, KeyboardState keyboardState)
    {
        _transform = transform;
        _keyboardState = keyboardState;
    }

    void IUpdatable.Update(float deltaTime)
    {
        foreach (Keys directionsKey in _directions.Keys)
        {
            if (_keyboardState.IsKeyDown(directionsKey))
            {
                _transform.Move(_directions[directionsKey] * _movementSpeed * deltaTime);
            }
        }
    }
}