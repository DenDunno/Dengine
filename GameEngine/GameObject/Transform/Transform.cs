using OpenTK.Mathematics;

public class Transform
{
    public Vector3 Position;
    public Vector3 Scale;
    public Quaternion Rotation;
    public Transform? Parent;
    
    private Vector3 _front = -Vector3.UnitZ;
    private Vector3 _up = Vector3.UnitY;
    private Vector3 _right = Vector3.UnitX;
    private float _pitch;
    private float _yaw = -MathHelper.PiOver2;

    public Transform() : this(Vector3.One, Quaternion.Identity, Vector3.Zero, null)
    {
    }

    public Transform(Vector3 position) : this(Vector3.One, Quaternion.Identity, position, null)
    {
    }
    
    public Transform(Vector3 position, Quaternion rotation) : this(Vector3.One, rotation, position, null)
    {
    }

    public Transform(Vector3 position, Transform parent) : this(Vector3.One, Quaternion.Identity, position, parent)
    {
    }

    private Transform(Vector3 scale, Quaternion rotation, Vector3 position, Transform? parent)
    {
        Position = position;
        Rotation = rotation;
        Scale = scale;
        Parent = parent;
    }

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
            UpdateOrientation();
        }
    }

    public float Yaw
    {
        get => MathHelper.RadiansToDegrees(_yaw);
        set
        {
            _yaw = MathHelper.DegreesToRadians(value);
            UpdateOrientation();
        }
    }

    public Matrix4 ModelMatrix
    {
        get
        {
            Matrix4 localMatrix = Matrix4.CreateScale(Scale) * Matrix4.CreateFromQuaternion(Rotation) * Matrix4.CreateTranslation(Position);
            
            if (Parent != null)
                return  localMatrix * Parent.ModelMatrix;

            return localMatrix;
        }
    }

    public void Move(Vector3 delta)
    {
        Position += delta;
    }

    public void Rotate(Vector3 rotationVector)
    {
        Rotation *= Quaternion.FromEulerAngles(rotationVector);
    }
    
    private void UpdateOrientation()
    {
        _front.X = MathF.Cos(_pitch) * MathF.Cos(_yaw);
        _front.Y = MathF.Sin(_pitch);
        _front.Z = MathF.Cos(_pitch) * MathF.Sin(_yaw);
        _front = Vector3.Normalize(_front);
        _right = Vector3.Normalize(Vector3.Cross(_front, Vector3.UnitY));
        _up = Vector3.Normalize(Vector3.Cross(_right, _front));
    }
}