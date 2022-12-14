using OpenTK.Mathematics;

public abstract class WorldFactory
{
    private readonly List<Rigidbody> _rigidbodies = new();
    private readonly Camera _camera;
    
    protected WorldFactory(PlayerInput playerInput)
    {
        Input = playerInput;
        CameraTransform = new Transform(new Vector3(0, 0, 3));
        _camera = new Camera(CameraTransform);
    }

    protected PlayerInput Input { get; }
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
        return new GameObject(new GameObjectData("Camera", CameraTransform)
        {
            Components = new List<IGameComponent>
            {
                new Timer(),
                new CameraControlling(CameraTransform, Input),
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