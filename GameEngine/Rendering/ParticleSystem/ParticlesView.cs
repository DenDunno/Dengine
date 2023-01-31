using OpenTK.Mathematics;

public class ParticlesView
{
    private readonly ParticlesBuffer _buffer;
    private readonly Model _view;
    private int _verticesCount;
    
    public ParticlesView(ParticlesBuffer buffer, Transform parent, int pool)
    {
        _buffer = buffer;
        _view = new Model(new RenderData()
        {
            Transform = parent,
            Mesh = GetViewMesh(pool),
            Material = new ParticleSystemMaterial()
        });
    }

    public void Initialize()
    {
        _view.Initialize();
        _view.Material.Bridge.SetInt("verticesCount", _verticesCount);
    }
    
    private Mesh GetViewMesh(int pool)
    {
        Mesh[] particles = new Mesh[pool];

        int width = (int)MathF.Sqrt(pool);

        for (int i = 0; i < particles.Length; ++i)
        {
            particles[i] = new HexagonMeshData(1f, new Vector3((float)i / width, (float)i % width, 0)).Build();
        }

        _verticesCount = particles.First().VerticesCount;
            
        return StaticBatching.Concatenate(particles);
    }

    public void Draw(in Matrix4 projectionMatrix, in Matrix4 viewMatrix)
    {
        _view.Material.Bridge.SetVector4Array("color", _buffer.Colors);
        _view.Material.Bridge.SetMatrix4Array("models", _buffer.Matrices);
        _view.Draw(projectionMatrix, viewMatrix);
    }

    public void Dispose()
    {
        _view.Dispose();
    }
}