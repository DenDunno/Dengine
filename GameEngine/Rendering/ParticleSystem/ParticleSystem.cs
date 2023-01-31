using OpenTK.Mathematics;

public class ParticleSystem : IDrawable
{
    private readonly ParticleSystemData _data;
    private readonly ParticlesUpdate _update;
    private readonly Transform _transform;
    private readonly ParticlesView _view;
    private float _clock;

    public ParticleSystem(Transform transform, ParticleSystemData data)
    {
        _data = data;
        _transform = transform;
        ParticlesBuffer buffer = new(data.Pool);
        _view = new ParticlesView(buffer, transform, data.Pool);
        _update = new ParticlesUpdate(buffer, transform, data);
    }

    void IGameComponent.Initialize()
    {
        _view.Initialize();
        _update.Update(0);
    }

    void IGameComponent.Update(float deltaTime)
    {
        _update.Update(deltaTime);

        if (Timer.Time >= _clock + _data.Rate)
        {
            _clock = Timer.Time;
            _update.Emit(_transform.Position);
        }
    }

    public void Draw(in Matrix4 projectionMatrix, in Matrix4 viewMatrix)
    {
        _view.Draw(in projectionMatrix, in viewMatrix);
    }

    public void Dispose()
    {
        _view.Dispose();
    }
}