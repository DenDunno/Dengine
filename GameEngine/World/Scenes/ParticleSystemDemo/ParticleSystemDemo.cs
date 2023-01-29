
using System.Drawing;

public class ParticleSystemDemo : IWorldFactory
{
    public List<GameObject> CreateGameObjects()
    {
        Camera camera = new(new PerspectiveProjection());

        return new List<GameObject>()
        {
            GameObjectFactory.CreateCamera(camera),
            GameObjectFactory.CreateParticleSystem(ParticleSystemData)
        };
    }

    private ParticleSystemData ParticleSystemData => new()
    {
        Color = new AnimationCurve<Color>(Color.Orange, Color.Aquamarine),
        Size = new AnimationCurve<float>(1, 2)
    };
}