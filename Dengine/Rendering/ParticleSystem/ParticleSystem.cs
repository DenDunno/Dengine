
public class ParticleSystem : IDrawable
{
    public bool Emitting = true;
    public readonly Transform Transform = new();
    private readonly ParticlesUpdate _update;
    private readonly ParticlesView _view;
    private readonly Timer _timer;

    public ParticleSystem(ParticleSystemData data)
    {
        _timer = new LocalTimer(1f / data.ParticlesPerSecond, Emit);
        _view = new ParticlesView(Transform, data);
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
    
    public void Draw()
    {
        _view.Draw();
    }

    public void Dispose()
    {
        _view.Dispose();
    }
}