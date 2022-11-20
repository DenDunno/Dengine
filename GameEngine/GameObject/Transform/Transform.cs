using OpenTK.Mathematics;

public class Transform
{
    public readonly TransformOrientation Orientation = new();
    public readonly ModelMatrix ModelMatrix = new();
    
    public Transform() : this(Vector3.Zero, Quaternion.Identity, null)
    {
    }

    public Transform(Vector3 position, Quaternion rotation) : this(position, rotation, null)
    {
    }

    public Transform(Vector3 position) : this(position, Quaternion.Identity, null)
    {
    }

    private Transform(Vector3 position, Quaternion rotation, Transform? parent)
    {
        ModelMatrix.Position = position;
        ModelMatrix.Rotation = rotation;
        ModelMatrix.Parent = parent;
    }

    public void Move(float x, float y, float z) => Move(new Vector3(x, y, z));

    public void Rotate(float x, float y, float z) => Rotate(new Vector3(x, y, z));

    public void Move(Vector3 delta)
    {
        ModelMatrix.Position += delta;
    }

    public void Rotate(Vector3 rotationVector)
    {
        ModelMatrix.Rotation *= Quaternion.FromEulerAngles(rotationVector);
    }
}