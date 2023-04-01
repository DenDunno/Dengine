
public class SkyboxFactory
{
    private readonly IReadOnlyList<string> _paths;

    public SkyboxFactory(string name)
    {
        _paths = Paths.GetSkybox(name);
    }
    
    public GameObject Create()
    {
        return GameObjectFactory.WithRenderData(new()
        {
            Mesh = MeshBuilder.FromObj("cube"),
            Material = new SkyboxMaterial(new Cubemap(_paths)),
        });
    }
}