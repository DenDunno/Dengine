using OpenTK.Mathematics;

public class AsteroidsAnimation : IGameComponent
{
    private readonly float _radius = 700;
    private readonly float _offset = 200f;
    private readonly int _count;
    private readonly AsteroidsMaterial _material;
    private readonly ShaderStorageBuffer<Matrix4> _modelMatrices = new();
    private readonly ShaderStorageBuffer<Vector4> _updateData = new();
    private readonly ComputeShader _update = new(Paths.GetShader("Asteroids/update"));
    
    public AsteroidsAnimation(Material material, int count)
    {
        _material = (AsteroidsMaterial)material;
        _count = count;
    }

    void IGameComponent.Initialize()
    {
        _material.Initialize();
        _update.Initialize();
        
        _material.Bridge.SetFloat("radius", _radius);
        _update.Bridge.SetFloat("rotationSpeed", 0.1f);
        _material.Bridge.BindShaderStorageBlock("Data", 1);
        _update.Bridge.BindShaderStorageBlock("UpdateData", 2);

        _modelMatrices.Bind();
        _modelMatrices.BufferData(GetMatrices());
        _modelMatrices.BindToPoint(1);
        
        _updateData.Bind();
        _updateData.BufferData(GetRotationVectors());
        _updateData.BindToPoint(2);
    }
    
    private Matrix4[] GetMatrices()
    {
        Matrix4[] matrices = new Matrix4[_count];

        for(int i = 0; i < _count; ++i)
        {
            float angle = (float)i / _count * 360.0f;

            float x = MathF.Sin(angle) * _radius + GetDisplacement();
            float y = GetDisplacement() * 0.4f; 
            float z = MathF.Cos(angle) * _radius + GetDisplacement();
            
            float scale = (Random.Shared.Next() % 20) / 5.0f + 1f;
            float rotAngle = (Random.Shared.Next() % 360);
            
            matrices[i] = Matrix4.CreateScale(scale) * 
                          Matrix4.CreateFromAxisAngle(new Vector3(0.4f, 0.6f, 0.8f), rotAngle) * 
                          Matrix4.CreateTranslation(x, y, z);
        }
        
        return matrices;
    }

    private Vector4[] GetRotationVectors()
    {
        Vector4[] vectors = new Vector4[_count];

        for (int i = 0; i < _count; ++i)
        {
            vectors[i] = new Vector4(Algorithms.RandomVector3(), 1);
        }

        return vectors;
    }

    private float GetDisplacement()
    {
        return Random.Shared.Next() % (int)(2 * _offset * 100) / 100.0f - _offset;
    }

    void IGameComponent.Update(float deltaTime)
    {
        _update.Bridge.SetFloat("deltaTime", deltaTime);
        
        _update.Dispatch(new Vector3i(_count / 32, 1, 1));
    }
}