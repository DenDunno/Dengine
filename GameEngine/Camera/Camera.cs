using OpenTK.Mathematics;

public class Camera
{
    private readonly float _nearClipPlaneDepth = 0.01f;
    private readonly float _farClipPlaneDepth = 100f;
    private readonly float _aspectRatio;
    private Vector3 _front = -Vector3.UnitZ;
    private Vector3 _up = Vector3.UnitY;
    private Vector3 _right = Vector3.UnitX;
    private float _pitch;
    private float _yaw = -MathHelper.PiOver2;

    public Camera(Vector3 position, float aspectRatio)
    {
        _aspectRatio = aspectRatio;
        Position = position;
    }
    
    public Vector3 Position { get; set; }
    public Vector3 Front => _front;
    public Vector3 Up => _up;
    public Vector3 Right => _right;
    
    public float Pitch
    {
        get => MathHelper.RadiansToDegrees(_pitch);
        set
        {
            var angle = MathHelper.Clamp(value, -89f, 89f);
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
