using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class Camera : IGameComponent
{
    public readonly Transform Transform;
    [EditorField] public readonly RenderSettings Settings = new();
    [EditorField] public readonly CameraProjection Projection;
    private readonly UniformData<CameraUniformData> _uniformData = new(0);

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

    public Matrix4 ViewMatrix => Matrix4.LookAt(Transform.Position, Transform.Position + Transform.Front, Transform.Up);

    void IGameComponent.Initialize()
    {
        _uniformData.Initialize();
    }

    public void UpdateViewProjectionMatrices()
    {
        Matrix4 projectionMatrix = Projection.Value;
        Matrix4 viewMatrix = ViewMatrix;

        GL.MatrixMode(MatrixMode.Projection);
        GL.LoadMatrix(ref projectionMatrix);
        
        GL.MatrixMode(MatrixMode.Modelview);
        GL.LoadMatrix(ref viewMatrix);
        
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