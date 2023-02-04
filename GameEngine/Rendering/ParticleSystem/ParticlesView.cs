using OpenTK.Mathematics;

public class ParticlesView
{
    private readonly int _verticesCount;
    private readonly Model _view;

    public ParticlesView(Transform parent, ParticleSystemData data)
    {
        _verticesCount = data.MeshDataSource.Build().VerticesCount;
        _view = new Model(new RenderData()
        {
            Transform = parent,
            Mesh = StaticBatching.Concatenate(data.MeshDataSource, data.Pool),
            Material = new ParticleSystemMaterial()
        });
    }

    public void Initialize()
    {
        _view.Initialize();
        _view.Material.Bridge.BindShaderStorageBlockToPoint("ParticlesData", 0);
        _view.Material.Bridge.SetInt("verticesCount", _verticesCount);
    }

    public void Draw(in Matrix4 projectionMatrix, in Matrix4 viewMatrix)
    {
        _view.Draw(projectionMatrix, viewMatrix);
    }

    public void Dispose()
    {
        _view.Dispose();
    }
}