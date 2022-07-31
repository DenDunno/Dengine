using OpenTK.Mathematics;

public class Transform
{
    private Matrix4 _modelMatrix;
    private Vector3 _position;
    
    public Transform() : this(Vector3.Zero, Quaternion.Identity)
    {
    }

    private Transform(Vector3 position, Quaternion rotation)
    {
        _modelMatrix = Matrix4.CreateTranslation(position) * Matrix4.CreateFromQuaternion(rotation);
    }
    
    public Vector3 Position => _position;
    public Matrix4 ModelMatrix => _modelMatrix;

    public Vector3 LocalToWorldPoint(Vector3 point)
    {
        return Vector3.TransformVector(point, _modelMatrix);
    }

    public void Move(in Vector3 movementVector)
    {
        Move(movementVector.X, movementVector.Y, movementVector.Z);
    }

    private void Move(float x, float y, float z)
    {
        UpdatePosition(_position.X + x, _position.Y + y, _position.Z + z);
    }
    
    public void Rotate(float x, float y, float z)
    {
        Rotate(new Vector3(x, y, z));
    }

    public void Rotate(Vector3 rotationVector)
    {
        _modelMatrix *= Matrix4.CreateFromQuaternion(Quaternion.FromEulerAngles(rotationVector));
    }

    private void UpdatePosition(float x, float y, float z)
    {
        _position.X = x;
        _position.Y = y;
        _position.Z = z;
        _modelMatrix[0, 3] = x;
        _modelMatrix[1, 3] = y;
        _modelMatrix[2, 3] = z;
    }
}