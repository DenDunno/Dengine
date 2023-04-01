using OpenTK.Mathematics;

public class Camera : IGameComponent
{
    [EditorField] public readonly RenderSettings Settings = new();
    [EditorField] public readonly CameraProjection Projection;
    private readonly CameraUniformBuffer _cameraUniformBuffer;
    public readonly Transform Transform;

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
        _cameraUniformBuffer = new CameraUniformBuffer(Transform, Projection);
    }

    private Matrix4 ViewMatrix => Matrix4.LookAt(Transform.Position, Transform.Position + Transform.Front, Transform.Up);

    public Vector2 ScreenToWorldCoordinates(Vector2 mousePosition) =>
        CameraUtils.ScreenToWorldCoordinates(ViewMatrix, Projection.Value, mousePosition);

    void IGameComponent.Initialize()
    {
        _cameraUniformBuffer.Initialize();
    }

    public void UpdateViewProjectionMatrices()
    {
        _cameraUniformBuffer.Update(ViewMatrix);
    }

    public void Dispose()
    {
        _cameraUniformBuffer.Dispose();
    }
}