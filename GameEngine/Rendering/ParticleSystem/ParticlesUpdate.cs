using OpenTK.Mathematics;

public class ParticlesUpdate
{
    private readonly ParticleSystemData _data;
    private readonly ParticlesBuffer _buffer;
    private readonly Particle[] _particles;
    private int _poolIndex;
    
    public ParticlesUpdate(ParticlesBuffer buffer, Transform parent, ParticleSystemData data)
    {
        _data = data;
        _buffer = buffer;
        _particles = new Particle[data.Pool];

        for (int i = 0; i < _particles.Length; ++i)
        {
            _particles[i] = new Particle()
            {
                Velocity = Algorithms.RandomVector2().ToVector3(),
                Transform =  new Transform(parent),
            };
        }
    }

    public void Update(float deltaTime)
    {
        for (int i = 0; i < _particles.Length; ++i)
        {
            if (_particles[i].Enabled == false)
            {
                continue;
            }

            _particles[i].ElapsedTime += deltaTime;
            _particles[i].Transform.Position += _particles[i].Velocity * deltaTime;

            if (_particles[i].ElapsedTime > _data.LifeTime)
            {
                _particles[i].Enabled = false;
                _particles[i].Color[3] = 0f;
            }
        }

        CopyData();
    }

    private void CopyData()
    {
        for (int i = 0; i < _particles.Length; ++i)
        {
            for (int j = 0; j < 4; ++j)
            {
                _buffer.Colors[4 * i + j] = _particles[i].Color[j];
                
                for (int k = 0; k < 4; ++k)
                {
                    _buffer.Matrices[16 * i + j * 4 + k] = _particles[i].Transform.ModelMatrix[j, k];
                }
            }
        }
    }

    public void Emit(Vector3 position)
    {
        _particles[_poolIndex].Transform.Position = position;
        _particles[_poolIndex].Enabled = true;
        _particles[_poolIndex].ElapsedTime = 0;
        _particles[_poolIndex].Color[3] = 1;

        MoveIndex();
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