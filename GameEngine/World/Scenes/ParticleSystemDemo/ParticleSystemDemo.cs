
public class ParticleSystemDemo : IWorldFactory
{
    public List<GameObject> CreateGameObjects()
    {
        Camera camera = new(new OrthographicProjection());
        
        return new List<GameObject>()
        {
            GameObjectFactory.CreateCamera(camera),
            GameObjectFactory.Point(new ParticleSpawner(camera))
        };
    }
}

