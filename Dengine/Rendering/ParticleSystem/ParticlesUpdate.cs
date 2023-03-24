using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class ParticlesUpdate
{    
    private readonly ComputeShader _updateShader = new(Paths.GetShader("Particles/update"));
    private readonly ShaderStorageBuffer<Particle> _shaderStorageBuffer = new();
    private readonly ParticleSystemData _data;
    private readonly Vector3i _updateDispatch;
    private int _poolIndex;
    
    public ParticlesUpdate(ParticleSystemData data)
    {
        int batchSize = (int)MathF.Ceiling(data.Pool / 32f);
        _updateDispatch = new(batchSize, 1, 1);
        _data = data;
    }

    public void Initialize()
    {
        _updateShader.Initialize();

        _updateShader.Bridge.SetInt("sizeArrayLength", _data.Size.Length);
        _updateShader.Bridge.SetInt("colorsSize", _data.Color.Length);
        _updateShader.Bridge.SetFloat("lifeTime", _data.LifeTime);
        _updateShader.Bridge.SetColorArray("colors", _data.Color);
        _updateShader.Bridge.SetFloatArray("sizes", _data.Size);
        _updateShader.Bridge.SetFloat("speed", _data.Speed);

        _shaderStorageBuffer.Bind();
        _shaderStorageBuffer.BufferData(EnumerableExtensions.CreateFilledArray<Particle>(_data.Pool));
        _shaderStorageBuffer.BindToPoint(0);
    }
    
    public void Update(float deltaTime)
    {
        _updateShader.Bridge.SetFloat("deltaTime", deltaTime);
        _updateShader.Dispatch(_updateDispatch);
    }

    public unsafe void Emit(Vector3 position, int particlesCount = 1)
    { 
        _shaderStorageBuffer.Bind();
        Particle* particles = _shaderStorageBuffer.MapBuffer(BufferAccess.WriteOnly);
        
        for (int i = 0; i < particlesCount; ++i)
        {
            ResetParticle(particles, position);
            MovePoolIndex();
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
        particles[_poolIndex].Scale = 0;
    }

    private void MovePoolIndex()
    {
        --_poolIndex;

        if (_poolIndex < 0)
        {
            _poolIndex = _data.Pool - 1;
        }
    }
}