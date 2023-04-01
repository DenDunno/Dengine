public class ParticlesView
{
    private readonly Model _view;

    public ParticlesView(Transform parent, ParticleSystemData data)
    {
        _view = new Model(new RenderData()
        {
            Transform = parent,
            Mesh = data.MeshDataSource.Build(),
            Material = new ParticleSystemMaterial(),
            DrawCommand = new DrawElementsInstanced(data.Pool)
        });
    }

    public void Initialize()
    {
        _view.Initialize();
        _view.Data.Material.Bridge.BindShaderStorageBlock("ParticlesData", 0);
    }

    public void Draw()
    {
        _view.Draw();
    }

    public void Dispose()
    {
        _view.Dispose();
    }
}