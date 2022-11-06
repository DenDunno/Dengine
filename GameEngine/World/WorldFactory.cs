using OpenTK.Windowing.GraphicsLibraryFramework;

public abstract class WorldFactory
{
    private readonly Window _window;
    private readonly List<Rigidbody> _rigidbodies = new();

    protected WorldFactory(Window window)
    {
        _window = window;
        Camera = new Camera(window.AspectRatio);
    }

    protected KeyboardState KeyboardState => _window.KeyboardState;
    protected Camera Camera { get; }
    protected NormalsViewer NormalsViewer { get; } = new();

    public World Create()
    {
        List<GameObject> gameObjects = CreateGameObjects();
        gameObjects.InsertFirst(CreateStaticPoint());

        return new World(Camera, gameObjects);
    }

    private GameObject CreateStaticPoint()
    {
        return new GameObject(new GameObjectData("Static point")
        {
            Components = new IUpdatable[]
            {
                new Timer(), 
                new FPSCounter(_window),
                new CameraControlling(Camera, _window.MouseState, _window.KeyboardState),
                new PhysicsSimulation(1 / 60f, _rigidbodies),
                NormalsViewer,
                Camera,
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