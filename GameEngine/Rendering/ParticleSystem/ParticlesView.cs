using OpenTK.Mathematics;

public class ParticlesView
{
    private readonly ParticlesBuffer _buffer;
    private readonly Model _view;
    private int _verticesCount;
    
    public ParticlesView(ParticlesBuffer buffer, Transform parent, ParticleSystemData data)
    {
        _buffer = buffer;
        _view = new Model(new RenderData()
        {
            Transform = parent,
            Mesh = GetViewMesh(data),
            Material = new ParticleSystemMaterial()
        });
    }

    public void Initialize()
    {
        _view.Initialize();
        _view.Material.Bridge.SetInt("verticesCount", _verticesCount);
    }
    
    private Mesh GetViewMesh(ParticleSystemData data)
    {
        _verticesCount = data.MeshDataSource.Build().VerticesCount;
            
        return StaticBatching.Concatenate(data.MeshDataSource, data.Pool);
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