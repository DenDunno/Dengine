using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class Camera : IGameComponent
{
    [EditorField] public readonly CameraProjection Projection;
    public readonly Transform Transform;

    public Camera(CameraProjection projection) : this(new Transform(new Vector3(0, 0, 10)), projection)
    {
    }

    public Camera(Transform transform, CameraProjection projection)
    {
        Transform = transform;
        Projection = projection;
    }

    public Matrix4 ViewMatrix => Matrix4.LookAt(Transform.Position, Transform.Position + Transform.Front, Transform.Up);

    void IGameComponent.Update(float deltaTime)
    {
        Matrix4 projectionMatrix = Projection.Value;
        Matrix4 viewMatrix = ViewMatrix;
        
        GL.MatrixMode(MatrixMode.Projection);
        GL.LoadMatrix(ref projectionMatrix);
        
        GL.MatrixMode(MatrixMode.Modelview);
        GL.LoadMatrix(ref viewMatrix);
    }
}
