using OpenTK.Mathematics;

public class Transform
{
    public Vector3 Position;
    public Quaternion Rotation;

    public Transform() : this(Vector3.Zero, Quaternion.Identity)
    {
    }
    
    public Transform(Vector3 position) : this(position, Quaternion.Identity)
    {
    }

    private Transform(Vector3 position, Quaternion rotation)
    {
        Position = position;
        Rotation = rotation;
    }

    public Matrix4 ModelMatrix => Matrix4.Transpose(Matrix4.CreateTranslation(Position)) * Matrix4.CreateFromQuaternion(Rotation);

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