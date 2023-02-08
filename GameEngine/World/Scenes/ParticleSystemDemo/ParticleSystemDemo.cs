using System.Drawing;
using OpenTK.Mathematics;

public class ParticleSystemDemo : IWorldFactory
{
    public List<GameObject> CreateGameObjects()
    {
        ParticleSystem particleSystem = new(new Transform(), Data);
        Camera camera = new(new OrthographicProjection());
        MouseInput mouseInput = new(camera, particleSystem);

        return new List<GameObject>()
        {
            GameObjectFactory.CreateParticleSystem(particleSystem),
            GameObjectFactory.CreateCamera(camera),
            GameObjectFactory.Point(mouseInput),
        };
    }

    private ParticleSystemData Data => new()
    {
        Color = new[]{Color.FromArgb(255, 124, 0), Color.Fuchsia, Color.FromArgb(0, 0, 255, 0)},
        Rotation = Vector3.UnitZ,
        Size = new[] {1, 0.5f, 0.3f, 0},
        ParticlesPerSecond = 10_000,
        Pool = 100_000,
        LifeTime = 10,
        Speed = 4,
        MeshDataSource = new TriangleMeshData(0.5f)
    };
}