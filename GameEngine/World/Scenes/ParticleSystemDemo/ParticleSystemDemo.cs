using OpenTK.Mathematics;

public class ParticleSystemDemo : IWorldFactory
{
    public List<GameObject> CreateGameObjects()
    {
        DynamicBatching dynamicBatching = new(new[]
        {
            new QuadMeshData(1).GetMeshData(),
            new QuadMeshData(1, Vector3.One).GetMeshData()
        });
        
        Camera camera = new(new OrthographicProjection());
        
        return new List<GameObject>()
        {
            GameObjectFactory.CreateCamera(camera),
            GameObjectFactory.Point(new ParticleSpawner(camera))
        };
    }
}

