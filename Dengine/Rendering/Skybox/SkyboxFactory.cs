using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class SkyboxFactory
{
    private readonly IReadOnlyList<string> _paths;
    private readonly Transform _cameraTransform;

    public SkyboxFactory(string name, Transform cameraTransform)
    {
        _cameraTransform = cameraTransform;
        _paths = Paths.GetSkybox(name);
    }
    
    public GameObject Create()
    {
        Transform transform = new() {Scale = Vector3.One * 10000};
        RenderData renderData = new()
        {
            Transform = transform,
            Mesh = MeshBuilder.FromObj("cube"),
            Material = new SkyboxMaterial(new Cubemap(_paths)),
        };

        return new GameObject(new GameObjectData("Skybox", transform)
        {
            Drawable = new Model(renderData),
            Components = new List<IGameComponent>
            {
                new Skybox(_cameraTransform, transform),
            }
        });
    }
}