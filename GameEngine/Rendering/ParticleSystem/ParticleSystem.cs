using OpenTK.Mathematics;

public class ParticleSystem : IDrawable
{
    private readonly ParticleSystemData _data;
    private readonly Transform _transform;
    private Model _view = null!;
    private float _clock;

    public ParticleSystem(Transform transform, ParticleSystemData data)
    {
        _transform = transform;
        _data = data;
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
            Material = new UnlitMaterial(new LitMaterialData()),
        });
        _view.Initialize();
    }
    
    void IGameComponent.Update(float deltaTime)
    {
        if (Timer.Time >= _clock + _data.Rate)
        {
            _clock = Timer.Time;
            Emit();
        }
    }

    private void Emit()
    {
    }

    public void Draw(in Matrix4 projectionMatrix, in Matrix4 viewMatrix)
    {
        _view.Draw(in projectionMatrix, in viewMatrix);
    }

    public void Dispose()
    {
    }
}