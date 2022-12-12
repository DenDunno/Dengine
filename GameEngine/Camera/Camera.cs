using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class Camera : IUpdatable
{
    private readonly float _nearClipPlane = 0.01f;
    private readonly float _farClipPlane = 1000f;
    private readonly int[] _viewport = new int[4];
    private readonly Transform _transform;

    public Camera(Transform transform)
    {
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

    public Matrix4 ProjectionMatrix
    {
        get
        {
            GL.GetInteger(GetPName.Viewport, _viewport);
            float aspectRatio = (float)_viewport[2] / _viewport[3];
            return Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver2, aspectRatio, _nearClipPlane, _farClipPlane);    
        }
    }

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
