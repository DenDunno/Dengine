using OpenTK.Mathematics;

public class ParticleSystem : IDrawable
{
    private readonly ParticlesView _view;
    private readonly ParticlesUpdate _update;

    public ParticleSystem(Transform transform, ParticleSystemData data)
    {
        ParticlesBuffer buffer = new(data.Pool);
        _view = new ParticlesView(buffer, transform, data.Pool);
        _update = new ParticlesUpdate(buffer, transform, data.Pool);
    }

    void IGameComponent.Initialize()
    {
        _view.Initialize();
        _update.Update(0);
    }

    void IGameComponent.Update(float deltaTime)
    {
        _update.Update(deltaTime);
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