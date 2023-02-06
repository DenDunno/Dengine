using MethodTimer;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class ParticlesUpdate
{
    private readonly ComputeShader _computeShader;
    private readonly ShaderStorageBuffer<Particle> _shaderStorageBuffer = new();
    private readonly ParticleSystemData _data;
    private int _poolIndex;

    public ParticlesUpdate(ParticleSystemData data)
    {
        int batchSize = (int)MathF.Ceiling(data.Pool / 32f);
        _computeShader = new(Paths.GetShader("Particles/update"), new Vector3i(batchSize, 1, 1));
        _data = data;
    }

    public void Initialize()
    {
        _computeShader.Initialize();
        _computeShader.Bridge.SetFloat("lifeTime", _data.LifeTime);
        _computeShader.Bridge.SetFloat("speed", _data.Speed);
        
        _shaderStorageBuffer.Bind();
        _shaderStorageBuffer.BufferData(EnumerableExtensions.CreateFilledArray<Particle>(_data.Pool));
        _shaderStorageBuffer.BufferBase(0);
    }
    
    public void Update(float deltaTime)
    {
        _computeShader.Bridge.SetFloat("deltaTime", deltaTime);
        _computeShader.Use();
    }

    [Time("Emit")]
    public unsafe void Emit(Vector3 position, int particlesCount = 1)
    { 
        _shaderStorageBuffer.Bind();
        Particle* particles = _shaderStorageBuffer.MapBuffer<Particle>(BufferAccess.WriteOnly);
        
        for (int i = 0; i < particlesCount; ++i)
        {
            ResetParticle(particles, position);
            MoveIndex();
        }
        
        _shaderStorageBuffer.UnMapBuffer();
    }

    private unsafe void ResetParticle(Particle* particles, Vector3 position)
    {
        particles[_poolIndex].Position = position.ToVector4();
        particles[_poolIndex].Enabled = 1;
        particles[_poolIndex].ElapsedTime = 0;
        particles[_poolIndex].Color = new Vector4(1, 0, 0, 1);
        particles[_poolIndex].Rotation.Z = 0;
        particles[_poolIndex].Scale = 1;
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