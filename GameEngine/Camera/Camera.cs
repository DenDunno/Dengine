using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class Camera : IUpdatable
{
    private readonly float _nearClipPlaneDepth = 0.01f;
    private readonly float _farClipPlaneDepth = 100f;
    private readonly float _aspectRatio;
    private readonly Transform _transform;

    public Camera(Transform transform)
    {
        int[] viewport = new int[4];
        GL.GetInteger(GetPName.Viewport, viewport);
        _aspectRatio = (float)viewport[2] / viewport[3];
        _transform = transform;
    }

    public Matrix4 ViewMatrix
    {
        get
        {
            Vector3 position = _transform.Position;
            TransformOrientation orientation = _transform.Orientation;
            return Matrix4.LookAt(position, position + orientation.Front, orientation.Up);
        }
    }

    public Matrix4 ProjectionMatrix => 
        Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver2, _aspectRatio, _nearClipPlaneDepth, _farClipPlaneDepth);

    void IUpdatable.Update(float deltaTime)
    {
        Matrix4 projectionMatrix = ProjectionMatrix;
        Matrix4 viewMatrix = ViewMatrix;
        
        GL.MatrixMode(MatrixMode.Projection);
        GL.LoadMatrix(ref projectionMatrix);
        
        GL.MatrixMode(MatrixMode.Modelview);
        GL.LoadMatrix(ref viewMatrix);
    }
}
