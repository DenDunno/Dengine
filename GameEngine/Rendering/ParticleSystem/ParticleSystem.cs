using OpenTK.Mathematics;

public class ParticleSystem : IGameComponent
{
    private readonly ParticleSystemData _data;
    private readonly Particle[] _particles;
    
    public ParticleSystem(int pool, ParticleSystemData data)
    {
        _data = data;
        _particles = new Particle[pool];
    }

    void IGameComponent.Update(float deltaTime)
    {
        
    }

    public void Emit(Vector3 point)
    {
    }
}