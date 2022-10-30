using OpenTK.Mathematics;

public class Transform
{
    public Vector3 Position;
    private Quaternion _rotation;
    private readonly Transform? _parent;

    public Transform() : this(Vector3.Zero, Quaternion.Identity, null)
    {
    }
    
    public Transform(Vector3 position) : this(position, Quaternion.Identity, null)
    {
    }

    private Transform(Vector3 position, Quaternion rotation, Transform? parent)
    {
        Position = position;
        _rotation = rotation;
        _parent = parent;
    }

    public Matrix4 ModelMatrix
    {
        get
        {
            Matrix4 localMatrix = Matrix4.CreateFromQuaternion(_rotation) * Matrix4.CreateTranslation(Position);
            
            if (_parent != null)
                return  localMatrix * _parent.ModelMatrix;

            return localMatrix;
        }
    }

    public void Move(float x, float y, float z)
    {
        Position.X += x;
        Position.Y += y;
        Position.Z += z;
    }

    public void Move(Vector3 delta)
    {
        Position += delta;
    }

    public void Rotate(float x, float y, float z)
    {
        Rotate(new Vector3(x, y, z));
    }

    public void Rotate(Vector3 rotationVector)
    {
        _rotation *= Quaternion.FromEulerAngles(rotationVector);
    }
}