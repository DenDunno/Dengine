
using OpenTK.Mathematics;

public class GPUInstancingDemo : IWorldFactory
{
    public List<GameObject> CreateGameObjects()
    {
        Camera camera = new();
        
        return new List<GameObject>()
        {
            GameObjectFactory.CreateCamera(camera),
            CreateSpace(camera),
            CreatePlanet(),
            CreateRock()
        };
    }

    private GameObject CreateSpace(Camera camera)
    {
        GameObject skybox = GameObjectFactory.CreateSkybox("Space", camera);
        skybox.Data.Components.Add(new RotationAnimation(skybox.Data.Transform, Vector3.One, 0.015f));

        return skybox;
    }

    private GameObject CreatePlanet()
    {
        return GameObjectFactory.WithRenderData("Planet", new RenderData()
        {
            Transform = new Transform(),
            Mesh = MeshBuilder.Quad(1f),
            Material = new Material(Paths.GetShader("vert"), Paths.GetShader("uv")),
        });
    }

    private GameObject CreateRock()
    {
        return GameObjectFactory.WithRenderData("Rock", new RenderData()
        {
            Transform = new Transform(new Vector3(0, 3, 0)),
            Mesh = MeshBuilder.Hexagon(2f),
            Material = new UnlitMaterial(new LitMaterialData()),
        });
    }
}