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

    public Matrix4 ModelMatrix => _modelMatrix;
    public Vector3 Position => _position;

    public Vector3 LocalToWorldPoint(Vector3 point)
    {
        return Vector3.TransformVector(point, _modelMatrix);
    }

    public void Move(float x, float y, float z)
    {
        UpdatePosition(_position.X + x, _position.Y + y, _position.Z + z);
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
        _modelMatrix.M14 = x;
        _modelMatrix.M24 = y;
        _modelMatrix.M34 = z;
    }
}