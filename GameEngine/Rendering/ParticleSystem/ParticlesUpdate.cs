using System.Drawing;
using OpenTK.Mathematics;

public class ParticlesUpdate
{
    private readonly ParticleSystemData _data;
    private readonly ParticlesBuffer _buffer;
    private readonly Particle[] _particles;
    private int _poolIndex;
    
    public ParticlesUpdate(ParticlesBuffer buffer, ParticleSystemData data)
    {
        _data = data;
        _buffer = buffer;
        _particles = new Particle[data.Pool];

        for (int i = 0; i < _particles.Length; ++i)
        {
            _particles[i] = new Particle()
            {
                Velocity = Algorithms.RandomVector2().ToVector3(),
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
            
            if (_particles[i].ElapsedTime > _data.LifeTime)
            {
                _particles[i].Enabled = false;
                continue;
            }
            
            float lerp = _particles[i].ElapsedTime / _data.LifeTime;
            
            _particles[i].Transform.Position += _particles[i].Velocity * deltaTime * _data.Speed;
            _particles[i].Transform.Rotation = Quaternion.FromEulerAngles(_data.Rotation.GetValue(lerp));
            _particles[i].Transform.Scale = Vector3.One * _data.Size.GetValue(lerp);
            
            Color color = _data.Color.GetValue(lerp);
            _particles[i].Color[0] = color.R / 255f;
            _particles[i].Color[1] = color.G / 255f;
            _particles[i].Color[2] = color.B / 255f;
            _particles[i].Color[3] = color.A / 255f;
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