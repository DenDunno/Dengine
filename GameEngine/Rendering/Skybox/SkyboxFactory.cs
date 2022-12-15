using OpenTK.Graphics.OpenGL;

public class SkyboxFactory
{
    private readonly IReadOnlyList<string> _paths;
    private readonly Transform _cameraTransform;

    public SkyboxFactory(string path, Transform cameraTransform)
    {
        _cameraTransform = cameraTransform;
        _paths = new List<string>()
        {
            $"Resources/{path}/right.jpg",
            $"Resources/{path}/left.jpg",
            $"Resources/{path}/top.jpg",
            $"Resources/{path}/bottom.jpg",
            $"Resources/{path}/back.jpg",
            $"Resources/{path}/front.jpg",
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
            Material = new SkyboxMaterial(new Cubemap(_paths), "Shaders/skyboxVert.glsl", "Shaders/skyboxFrag.glsl"),
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