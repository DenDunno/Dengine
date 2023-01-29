using OpenTK.Mathematics;

public class ParticleSystem : IDrawable
{
    private readonly ParticleSystemData _data;
    private readonly Particle[] _particles;
    private readonly Transform _transform;
    private Model _view = null!;
    private readonly MovementAnimation[] _animations;
    private readonly float[] _matrices;

    private readonly float[] _colors = 
    {
        0, 0, 1, 1, 
        0, 1, 0, 1, 
        1, 0, 0, 1, 
        0, 1, 0, 0.5f,
        0, 0, 1, 0.5f,
    };
    
    public ParticleSystem(Transform transform, ParticleSystemData data)
    {
        _particles = Enumerable.Repeat(new Particle(), data.Pool).ToArray();
        _animations = new MovementAnimation[data.Pool];
        
        for (int i = 0; i < _animations.Length; ++i)
        {
            _animations[i] = new MovementAnimation(_particles[i].Transform, Vector3.One * i);
        }
        _transform = transform;
        _data = data;
        _matrices = new float[16 * _data.Pool];
    }

    void IGameComponent.Initialize()
    {
        Mesh[] particles = new Mesh[_data.Pool];

        for (int i = 0; i < particles.Length; ++i)
        {
            particles[i] = new HexagonMeshData(1f, Vector3.One * i).Build();
        }
        
        _view = new Model(new RenderData()
        {
            Transform = _transform,
            Mesh = StaticBatching.Concatenate(particles),
            Material = new ParticleSystemMaterial()
        });
        _view.Initialize();
        
        _view.Material.Bridge.SetInt("verticesCount", particles.First().VerticesCount);
        _view.Material.Bridge.SetFloatArray("color", _colors);
    }

    void IGameComponent.Update(float deltaTime)
    {
        foreach (IGameComponent animation in _animations)
        {
            animation.Update(deltaTime);
        }
    }
    
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

        //_view.Material.Bridge.SetArray("color", _data.Pool, _colors);

        _view.Draw(in projectionMatrix, in viewMatrix);
    }

    public void Dispose()
    {
    }
}