using OpenTK.Mathematics;

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
        _view.Material.Bridge.BindShaderStorageBlockToPoint("ParticlesData", 0);
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