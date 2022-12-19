using OpenTK.Mathematics;

public abstract class WorldFactory
{
    private readonly Camera _camera;
    
    protected WorldFactory(PlayerInput playerInput)
    {
        Input = playerInput;
        CameraTransform = new Transform(new Vector3(0, 0, 3));
        _camera = new Camera(CameraTransform);
    }

    protected PlayerInput Input { get; }
    protected Transform CameraTransform { get; }

    public World Create()
    {
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
                new CameraControlling(CameraTransform, Input),
                new PostProcessing(),
                _camera,
            },

            Model = new Gizmo()
        });
    }

    protected abstract List<GameObject> CreateGameObjects();
}