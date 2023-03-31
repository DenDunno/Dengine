using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class Camera : IGameComponent
{
    [EditorField] public readonly RenderSettings Settings = new();
    [EditorField] public readonly CameraProjection Projection;
    private readonly UniformBuffer<Matrix4> _viewProjMatrix = new();
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
    }

    public Matrix4 ViewMatrix => Matrix4.LookAt(Transform.Position, Transform.Position + Transform.Front, Transform.Up);

    public Vector2 ScreenToWorldCoordinates(Vector2 screenPosition) =>
        CameraUtils.ScreenToWorldCoordinates(ViewMatrix, Projection.Value, screenPosition);

    void IGameComponent.Initialize()
    {
        _viewProjMatrix.Bind();
        _viewProjMatrix.BindToPoint(0);
        _viewProjMatrix.BufferData(Matrix4.Identity);
    }
    
    void IGameComponent.Update(float deltaTime)
    {
        Matrix4 projectionMatrix = Projection.Value;
        Matrix4 viewMatrix = ViewMatrix;

        _viewProjMatrix.Bind();
        _viewProjMatrix.BufferData(new[]{viewMatrix, projectionMatrix});
        
        GL.MatrixMode(MatrixMode.Projection);
        GL.LoadMatrix(ref projectionMatrix);
        
        GL.MatrixMode(MatrixMode.Modelview);
        GL.LoadMatrix(ref viewMatrix);
    }
}