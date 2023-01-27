using OpenTK.Mathematics;

public class ParticleSystemDemo : IWorldFactory
{
    public List<GameObject> CreateGameObjects()
    {
        Camera camera = new(new PerspectiveProjection());
        
        return new List<GameObject>()
        {
            GameObjectFactory.CreateCamera(camera),
            new(new GameObjectData("Quad", new Transform())
            {
                Drawable = new Model(new RenderData()
                {
                    Transform = new Transform(),
                    Material = new UnlitMaterial(new LitMaterialData()),
                    Mesh = StaticBatching.Concatenate(new List<Mesh>()
                    {
                        new QuadMeshData(1f).Build(),
                        new QuadMeshData(1f, Vector3.One).Build(),
                    })
                })
            })
        };
    }
}

