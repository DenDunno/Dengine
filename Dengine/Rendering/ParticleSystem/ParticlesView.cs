public class ParticlesView
{
    private readonly Model _view;

    public ParticlesView(Transform parent, ParticleSystemData data)
    {
        _view = new Model(new RenderData(data.MeshDataSource.Build(), new ParticleSystemMaterial(), new DrawElementsInstanced(data.Pool))
        {
            Transform = parent
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