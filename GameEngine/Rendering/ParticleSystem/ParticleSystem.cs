using OpenTK.Mathematics;

public class ParticleSystem : IDrawable
{
    public bool Enabled = true;
    public readonly Transform Transform;
    private readonly ParticleSystemData _data;
    private readonly ParticlesUpdate _update;
    private readonly ParticlesView _view;
    private float _clock;

    public ParticleSystem(Transform transform, ParticleSystemData data)
    {
        _data = data;
        Transform = transform;
        _view = new ParticlesView(transform, data);
        _update = new ParticlesUpdate(data);
    }

    void IGameComponent.Initialize()
    {
        _view.Initialize();
        _update.Initialize();
    }

    void IGameComponent.Update(float deltaTime)
    {
        _update.Update(deltaTime);

        if (Enabled && Timer.Time >= _clock + _data.Rate)
        {
            _clock = Timer.Time;
            _update.Emit(Transform.Position);
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