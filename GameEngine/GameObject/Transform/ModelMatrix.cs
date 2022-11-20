using OpenTK.Mathematics;

public class ModelMatrix
{
    private Matrix4 _scaleMatrix;
    private Matrix4 _rotationMatrix;
    private Matrix4 _translationMatrix;
    public Transform? Parent;

    public ModelMatrix(Vector3 scale, Quaternion rotation, Vector3 translation, Transform? parent)
    {
        SetScale(scale);
        SetRotation(rotation);
        SetTranslation(translation);
        SetParent(parent);
    }
    
    public Vector3 Scale { get; private set; }
    public Quaternion Rotation { get; private set; }
    public Vector3 Position { get; private set; }
    
    public Matrix4 Value
    {
        get
        {
            Matrix4 localMatrix = _scaleMatrix * _rotationMatrix * _translationMatrix;
            
            if (Parent != null)
                return  localMatrix * Parent.ModelMatrix;

            return localMatrix;
        }
    }

    public void SetParent(Transform? parent)
    {
        Parent = parent;
    }
    
    public void SetScale(Vector3 scale)
    {
        Scale = scale;
        _scaleMatrix = Matrix4.CreateScale(scale);
    }

    public void SetRotation(Quaternion rotation)
    {
        Rotation = rotation;
        _rotationMatrix = Matrix4.CreateFromQuaternion(rotation);
    }

    public void SetTranslation(Vector3 position)
    {
        Position = position;
        _translationMatrix = Matrix4.CreateTranslation(position);
    }
}