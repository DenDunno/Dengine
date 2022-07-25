using OpenTK.Mathematics;

public class Transform
{
    private Matrix4 _modelMatrix;

    public Transform() : this(Vector3.Zero, Quaternion.Identity)
    {
    }
    
    public Transform(Vector3 position, Quaternion rotation)
    {
        _position = position;
        _rotation = rotation;
    }

    public void Move(Vector3 delta)
    {
    }
    
    public void Rotate(Quaternion delta)
    {
    }
}