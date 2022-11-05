using OpenTK.Windowing.GraphicsLibraryFramework;

public abstract class WorldFactory
{
    private readonly Window _window;
    private readonly Camera _camera;
    private readonly List<Rigidbody> _rigidbodies = new();

    protected WorldFactory(Window window)
    {
        _window = window;
        _camera = new Camera(window.AspectRatio);
    }

    public KeyboardState KeyboardState => _window.KeyboardState;
    public Camera Camera => _camera;
    
    public World Create()
    {
        List<GameObject> gameObjects = CreateGameObjects();
        gameObjects.InsertFirst(CreateStaticPoint());

        return new World(_camera, gameObjects);
    }

    private GameObject CreateStaticPoint()
    {
        return new GameObject(new GameObjectData
        {
            Components = new IUpdatable[]
            {
                new Timer(), 
                new FPSCounter(_window),
                new CameraControlling(_camera, _window.MouseState, _window.KeyboardState),
                new PhysicsSimulation(1 / 60f, _rigidbodies),
                _camera,
            },
            
            Model = new Gizmo()
        });
    }

    protected void AddRigidbody(Rigidbody rigidbody)
    {
        _rigidbodies.Add(rigidbody);
    }
    
    protected abstract List<GameObject> CreateGameObjects();
}