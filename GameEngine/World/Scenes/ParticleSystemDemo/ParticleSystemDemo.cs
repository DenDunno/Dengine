
public class ParticleSystemDemo : IWorldFactory
{
    public List<GameObject> CreateGameObjects(PlayerInput playerInput)
    {
        Camera camera = new(new OrthographicProjection());
        
        return new List<GameObject>()
        {
            GameObjectFactory.CreateCamera(camera),
            GameObjectFactory.Point(new ParticleSpawner(playerInput.Mouse, camera))
        };
    }
}

