
public class ParticleSystemDemo : IWorldFactory
{
    public List<GameObject> CreateGameObjects()
    {
        Camera camera = new(new PerspectiveProjection());

        return new List<GameObject>()
        {
            GameObjectFactory.CreateCamera(camera),
            GameObjectFactory.CreateParticleSystem(new ParticleSystemData())
        };
    }
}