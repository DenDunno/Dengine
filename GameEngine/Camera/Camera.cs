using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class Camera : IGameComponent
{
    public readonly Transform Transform;
    [EditorField] private readonly float _nearClipPlane = 0.01f;
    [EditorField] private readonly float _farClipPlane = 10000f;
    private readonly int[] _viewport = new int[4];

    public Camera(Transform transform)
    {
        Transform = transform;
    }

    public Matrix4 ViewMatrix => Matrix4.LookAt(Transform.Position, Transform.Position + Transform.Front, Transform.Up);

    public Matrix4 ProjectionMatrix
    {
        get
        {
            GL.GetInteger(GetPName.Viewport, _viewport);
            float aspectRatio = (float)_viewport[2] / _viewport[3];
            return Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver2, aspectRatio, _nearClipPlane, _farClipPlane);    
        }
    }

    void IGameComponent.Update(float deltaTime)
    {
        Matrix4 projectionMatrix = ProjectionMatrix;
        Matrix4 viewMatrix = ViewMatrix;
        
        GL.MatrixMode(MatrixMode.Projection);
        GL.LoadMatrix(ref projectionMatrix);
        
        GL.MatrixMode(MatrixMode.Modelview);
        GL.LoadMatrix(ref viewMatrix);
    }
}
