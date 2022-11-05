using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class Camera : IUpdatable
{
    private readonly float _nearClipPlaneDepth = 0.01f;
    private readonly float _farClipPlaneDepth = 100f;
    private readonly float _aspectRatio;
    private Vector3 _front = -Vector3.UnitZ;
    private Vector3 _up = Vector3.UnitY;
    private Vector3 _right = Vector3.UnitX;
    private float _pitch;
    private float _yaw = -MathHelper.PiOver2;

    public Camera(float aspectRatio)
    {
        _aspectRatio = aspectRatio;
    }

    public Vector3 Position { get; set; } = new(0, 0, 3);
    public Vector3 Front => _front;
    public Vector3 Up => _up;
    public Vector3 Right => _right;
    
    public float Pitch
    {
        get => MathHelper.RadiansToDegrees(_pitch);
        set
        {
            float angle = MathHelper.Clamp(value, -89f, 89f);
            _pitch = MathHelper.DegreesToRadians(angle);
            UpdateVectors();
        }
    }
    
    public float Yaw
    {
        get => MathHelper.RadiansToDegrees(_yaw);
        set
        {
            _yaw = MathHelper.DegreesToRadians(value);
            UpdateVectors();
        }
    }
    
    public Matrix4 ViewMatrix => Matrix4.LookAt(Position, Position + _front, _up);

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
    
    private void UpdateVectors()
    {
        _front.X = MathF.Cos(_pitch) * MathF.Cos(_yaw);
        _front.Y = MathF.Sin(_pitch);
        _front.Z = MathF.Cos(_pitch) * MathF.Sin(_yaw);
        _front = Vector3.Normalize(_front);
        _right = Vector3.Normalize(Vector3.Cross(_front, Vector3.UnitY));
        _up = Vector3.Normalize(Vector3.Cross(_right, _front));
    }
}
