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
        Color = new AnimationCurve<Color>(Color.DarkOrange, Color.FromArgb(0, 0, 0, 255)),
        Rotation = new AnimationCurve<Vector3>(new Vector3(0, 0, 0), new Vector3(0, 0, 4 * MathF.PI)),
        Size = new AnimationCurve<float>(new CurvePart<float>[]
        {
            new()
            {
                FirstKey = new CurveKey<float>(1, 0),
                SecondKey = new CurveKey<float>(2, 0.5f),
                EasingFunction = EasingFunctions.InOutQuad
            },
            
            new()
            {
                FirstKey = new CurveKey<float>(2, 0.5f),
                SecondKey = new CurveKey<float>(1, 1f),
                EasingFunction = EasingFunctions.InOutQuad
            }
        }),
        ParticlesPerSecond = 3000,
        Pool = 100_000,
        LifeTime = 8,
        MeshDataSource = new TriangleMeshData(0.5f)
    };
}