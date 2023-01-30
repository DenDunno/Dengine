
public class ParticlesUpdate
{
    private readonly ParticlesBuffer _buffer;
    private readonly Particle[] _particles;
    
    public ParticlesUpdate(ParticlesBuffer buffer, Transform parent, int pool)
    {
        _buffer = buffer;
        _particles = new Particle[pool];

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
            _particles[i].Transform.Position += _particles[i].Velocity * deltaTime;
        }
        
        int index = 0;
        
        for (int i = 0; i < _particles.Length; ++i)
        {
            for (int j = 0; j < 4; ++j)
            {
                for (int k = 0; k < 4; ++k, ++index)
                {
                    _buffer.Matrices[index] = _particles[i].Transform.ModelMatrix[j, k];
                }
            }
        }
    }
}