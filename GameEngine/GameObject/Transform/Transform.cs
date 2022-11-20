using OpenTK.Mathematics;

public class Transform
{
    public readonly TransformOrientation Orientation = new();
    public Vector3 Position;
    public Vector3 Scale;
    public Quaternion Rotation;
    public Transform? Parent;

    public Transform() : this(Vector3.One, Quaternion.Identity, Vector3.Zero, null)
    {
    }

    public Transform(Vector3 position, Quaternion rotation) : this(Vector3.One, rotation, position, null)
    {
    }

    public Transform(Vector3 position) : this(Vector3.One, Quaternion.Identity, position, null)
    {
    }

    private Transform(Vector3 scale, Quaternion rotation, Vector3 position, Transform? parent)
    {
        Position = position;
        Rotation = rotation;
        Scale = scale;
        Parent = parent;
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
}