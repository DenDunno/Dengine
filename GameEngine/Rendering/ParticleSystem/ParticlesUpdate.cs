using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public unsafe class ParticlesUpdate
{
    private readonly ShaderStorageBuffer<Particle> _shaderStorageBuffer;
    private readonly ParticleSystemData _data;
    private Particle* _particles;
    private int _poolIndex;

    public ParticlesUpdate(ParticleSystemData data)
    {
        Particle[] particles = EnumerableExtensions.CreateFilledArray<Particle>(data.Pool);
        _shaderStorageBuffer = new ShaderStorageBuffer<Particle>(particles);
        _data = data;
    }

    public void Initialize()
    {
        _shaderStorageBuffer.BindToPoint(0);
        _shaderStorageBuffer.ReleaseData();
    }
    
    public void Update(float deltaTime)
    {
        _shaderStorageBuffer.Bind();
        _particles = _shaderStorageBuffer.MapBuffer<Particle>(BufferAccess.WriteOnly);

        Parallel.For(0, _data.Pool, i => UpdateParticle(i, deltaTime));

        _shaderStorageBuffer.UnMapBuffer();
    }

    private void UpdateParticle(int index, float deltaTime)
    {
        if (_particles[index].Enabled == 0)
        {
            return;
        }
            
        _particles[index].ElapsedTime += deltaTime;
            
        if (_particles[index].ElapsedTime > _data.LifeTime)
        {
            _particles[index].Enabled = 0;
            return;
        }

        _particles[index].Position += _particles[index].Velocity * deltaTime * _data.Speed;
        SetParticleLerp(index, _particles[index].ElapsedTime / _data.LifeTime);
    }

    public void Emit(Vector3 position)
    {
        _particles[_poolIndex].Position = position.ToVector4();
        _particles[_poolIndex].Enabled = 1;
        _particles[_poolIndex].ElapsedTime = 0;

        SetParticleLerp(_poolIndex, 0);
        MoveIndex();
    }

    private void SetParticleLerp(int particle, float lerp)
    {
        _particles[particle].Color = _data.Color.GetValue(lerp).ToVector4() / 255f;
        _particles[particle].Rotation = _data.Rotation.GetValue(lerp).ToVector4();
        _particles[particle].Scale = _data.Size.GetValue(lerp);
    }

    private void MoveIndex()
    {
        --_poolIndex;

        if (_poolIndex < 0)
        {
            _poolIndex = _data.Pool - 1;
        }
    }
}