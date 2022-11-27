using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

public abstract class WorldFactory
{
    private readonly Window _window;
    private readonly List<Rigidbody> _rigidbodies = new();
    private Camera _camera;
    
    protected WorldFactory(Window window)
    {
        _window = window;
        CameraTransform = new Transform(new Vector3(0, 0, 3));
        _camera = new Camera(window.AspectRatio, CameraTransform);
    }

    protected KeyboardState KeyboardState => _window.KeyboardState;
    protected Transform CameraTransform { get; }
    protected NormalsViewer NormalsViewer { get; } = new();

    public World Create()
    {
        List<GameObject> gameObjects = CreateGameObjects();
        gameObjects.InsertFirst(CreateStaticPoint());

        return new World(_camera, gameObjects);
    }

    private GameObject CreateStaticPoint()
    {
        return new GameObject(new GameObjectData("Static point")
        {
            Dependencies = new object[]
            {
                new Timer(), 
                new FPSCounter(_window),
                new CameraControlling(CameraTransform, _window.MouseState, _window.KeyboardState),
                new PhysicsSimulation(1 / 60f, _rigidbodies),
                NormalsViewer,
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