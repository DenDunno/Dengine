using OpenTK.Mathematics;

public class Transform
{
    public Vector3 Position;
    public Vector3 Scale = Vector3.One;
    public Quaternion Rotation;
    public readonly Transform? Parent;

    public Transform() : this(Vector3.Zero, Quaternion.Identity, null)
    {
    }
    
    public Transform(Vector3 position) : this(position, Quaternion.Identity, null)
    {
    }

    public Transform(Vector3 position, Quaternion rotation) : this(position, rotation, null)
    {
    }

    private Transform(Vector3 position, Quaternion rotation, Transform? parent)
    {
        Position = position;
        Rotation = rotation;
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
        Rotation *= Quaternion.FromEulerAngles(rotationVector);
    }
}