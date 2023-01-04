using OpenTK.Mathematics;

public abstract class WorldFactory
{
    private readonly Camera _camera;
    
    protected WorldFactory()
    {
        CameraTransform = new Transform(new Vector3(0, 0, 3));
        _camera = new Camera(CameraTransform);
    }

    protected PlayerInput Input { get; private set; } = null!;
    protected Transform CameraTransform { get; }

    public World Create(PlayerInput playerInput)
    {
        Input = playerInput;
        List<GameObject> gameObjects = CreateGameObjects();
        gameObjects.Add(CreateCamera());

        return new World(_camera, gameObjects);
    }

    private GameObject CreateCamera()
    {
        return new GameObject(new GameObjectData("Camera", CameraTransform)
        {
            Components = new List<IGameComponent>
            {
                new Timer(),
                new PostProcessing(),
                _camera,
                Stats.Instance
            },

            Model = new Gizmo()
        });
    }

    protected GameObject CreateSkybox(string name)
    {
        return new SkyboxFactory(name, CameraTransform).Create();
    }
    
    protected abstract List<GameObject> CreateGameObjects();
}