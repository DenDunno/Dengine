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

    public Vector4 LocalToWorldPoint(Vector4 point)
    {
        return _modelMatrix * point;
    }

    public void SetPosition(float x, float y, float z)
    {
        UpdatePosition(x, y, z);
    }

    public void SetRotation(float x, float y, float z)
    {
    }

    public void Move(float x, float y, float z)
    {
        UpdatePosition(_position.X + x, _position.Y + y, _position.Z + z);
    }

    public void Rotate(float x, float y, float z)
    {
        _modelMatrix *= Matrix4.CreateFromQuaternion(Quaternion.FromEulerAngles(x, y, z));
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