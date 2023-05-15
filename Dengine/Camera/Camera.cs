using OpenTK.Mathematics;

public class Camera : IGameComponent
{
    public readonly Transform Transform;
    [EditorField] public readonly RenderSettings Settings;
    [EditorField] public readonly CameraProjection Projection;
    private readonly UniformData<CameraUniformData> _uniformData = new(0);

    public Camera(CameraProjection projection, RenderSettings renderSettings) : this(new Transform(), projection, renderSettings)
    {
    }
    
    public Camera(Transform transform) : this(transform, new PerspectiveProjection(), new RenderSettings())
    {
    }

    public Camera(CameraProjection projection) : this(new Transform(), projection, new RenderSettings())
    {
    }

    public Camera(Transform transform, CameraProjection projection, RenderSettings renderSettings)
    {
        Transform = transform;
        Projection = projection;
        Settings = renderSettings;
    }

    public Matrix4 ViewMatrix => Matrix4.LookAt(Transform.Position, Transform.Position + Transform.Front, Transform.Up);

    void IGameComponent.Initialize()
    {
        _uniformData.Initialize();
    }

    public void UpdateViewProjectionMatrices()
    {
        _uniformData.Data.Position = new Vector4(Transform.Position);
        _uniformData.Data.ViewMatrix = ViewMatrix;
        _uniformData.Data.ProjectionMatrix = Projection.Value;
        
        _uniformData.Map();
    }

    public void Dispose()
    {
        _uniformData.Dispose();
    }
}