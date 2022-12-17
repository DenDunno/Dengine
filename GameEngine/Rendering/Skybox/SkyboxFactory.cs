using OpenTK.Graphics.OpenGL;

public class SkyboxFactory
{
    private readonly IReadOnlyList<string> _paths;
    private readonly Transform _cameraTransform;

    public SkyboxFactory(string name, Transform cameraTransform)
    {
        _cameraTransform = cameraTransform;
        _paths = new List<string>()
        {
            $"Resources/{name}/right.jpg",
            $"Resources/{name}/left.jpg",
            $"Resources/{name}/top.jpg",
            $"Resources/{name}/bottom.jpg",
            $"Resources/{name}/back.jpg",
            $"Resources/{name}/front.jpg",
        };
    }
    
    public GameObject Create()
    {
        Transform transform = new();
        RenderData renderData = new()
        {
            Transform = transform,
            Mesh = MeshBuilder.Cube(50),
            BufferUsageHint = BufferUsageHint.StaticDraw,
            Material = new SkyboxMaterial(new Cubemap(_paths)),
        };

        return new GameObject(new GameObjectData("Skybox", transform)
        {
            Model = new Model(renderData),
            Components = new List<IGameComponent>
            {
                new Skybox(_cameraTransform, transform),
            }
        });
    }
}