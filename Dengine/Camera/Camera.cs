using OpenTK.Mathematics;

public class Camera : IGameComponent
{
    public readonly Transform Transform;
    [EditorField] public readonly RenderSettings Settings = new();
    [EditorField] public readonly CameraProjection Projection;
    private readonly UniformData<CameraUniformData> _uniformData = new(0);
    private CameraUniformData _data;

    public Camera() : this(new Transform(new Vector3(0, 0, 10)), new PerspectiveProjection())
    {
    }

    public Camera(Transform transform) : this(transform, new PerspectiveProjection())
    {
    }

    public Camera(CameraProjection projection) : this(new Transform(new Vector3(0, 0, 10)), projection)
    {
    }

    private Camera(Transform transform, CameraProjection projection)
    {
        Transform = transform;
        Projection = projection;
    }

    private Matrix4 ViewMatrix => Matrix4.LookAt(Transform.Position, Transform.Position + Transform.Front, Transform.Up);

    public Vector2 ScreenToWorldCoordinates(Vector2 mousePosition) =>
        CameraUtils.ScreenToWorldCoordinates(ViewMatrix, Projection.Value, mousePosition);

    void IGameComponent.Initialize()
    {
        _uniformData.Initialize();
    }

    public void UpdateViewProjectionMatrices()
    {
        _data.Position = new Vector4(Transform.Position);
        _data.ViewMatrix = ViewMatrix;
        _data.ProjectionMatrix = Projection.Value;
        
        _uniformData.Map(_data);
    }

    public void Dispose()
    {
        _uniformData.Dispose();
    }
}