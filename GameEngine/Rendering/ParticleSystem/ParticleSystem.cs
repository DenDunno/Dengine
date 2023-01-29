using MethodTimer;
using OpenTK.Mathematics;

public class ParticleSystem : IDrawable
{
    private readonly ParticleSystemData _data;
    private readonly Particle[] _particles;
    private readonly Transform _transform;
    private Model _view = null!;
    private readonly float[] _matrices;
    private readonly float[] _colors;

    public ParticleSystem(Transform transform, ParticleSystemData data)
    {
        _data = data;
        _transform = transform;
        _particles = new Particle[data.Pool];
        _matrices = new float[16 * data.Pool];
        _colors = Enumerable.Repeat(1f, 4 * _data.Pool).ToArray();
        
        for (int i = 0; i < _particles.Length; ++i)
        {
            _particles[i] = new Particle()
            {
                Velocity = Algorithms.RandomVector2().ToVector3(),
                Transform =  new Transform(_transform),
            };
        }
    }

    void IGameComponent.Initialize()
    {
        Mesh[] particlesMesh = GetParticlesMesh();
        SetupView(particlesMesh);
    }

    private Mesh[] GetParticlesMesh()
    {
        Mesh[] particles = new Mesh[_data.Pool];

        for (int i = 0; i < particles.Length; ++i)
        {
            particles[i] = new HexagonMeshData(1f, Vector3.UnitX * i).Build();
        }

        return particles;
    }
    
    private void SetupView(Mesh[] particles)
    {
        _view = new Model(new RenderData()
        {
            Transform = _transform,
            Mesh = StaticBatching.Concatenate(particles),
            Material = new ParticleSystemMaterial()
        });
        
        _view.Initialize();
        _view.Material.Bridge.SetInt("verticesCount", particles.First().VerticesCount);
    }

    void IGameComponent.Update(float deltaTime)
    {
        for (int i = 0; i < _particles.Length; ++i)
        {
            _particles[i].Transform.Position += _particles[i].Velocity * deltaTime;
        }
    }
    
    [Time("Particles")]
    public void Draw(in Matrix4 projectionMatrix, in Matrix4 viewMatrix)
    {
        int index = 0;
        
        for (int i = 0; i < _particles.Length; ++i)
        {
            for (int j = 0; j < 4; ++j)
            {
                for (int k = 0; k < 4; ++k, ++index)
                {
                    _matrices[index] = _particles[i].Transform.ModelMatrix[j, k];
                }
            }
        }
        
        _view.Material.Bridge.SetVector4Array("color", _colors);
        _view.Material.Bridge.SetMatrix4Array("models", _matrices);

        _view.Draw(in projectionMatrix, in viewMatrix);
    }

    public void Dispose()
    {
    }
}