using OpenTK.Mathematics;

public class ParticleSystem : IDrawable
{
    public bool Emitting = true;
    public readonly Transform Transform;
    private readonly ParticlesUpdate _update;
    private readonly ParticlesView _view;
    private readonly Timer _timer;

    public ParticleSystem(Transform transform, ParticleSystemData data)
    {
        Transform = transform;
        _timer = new LocalTimer(1f / data.ParticlesPerSecond, Emit);
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

        if (Emitting)
        {
            _timer.Update(deltaTime);
        }
    }
    
    private void Emit()
    {
        _update.Emit(Transform.Position, (int)(_timer.Difference / _timer.Rate));
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