using OpenTK.Mathematics;

public class ModelMatrix
{
    public Vector3 Position;
    public Vector3 Scale = Vector3.One;
    public Quaternion Rotation;
    public Transform? Parent;
    
    public Matrix4 Value
    {
        get
        {
            Matrix4 localMatrix = Matrix4.CreateScale(Scale) * Matrix4.CreateFromQuaternion(Rotation) * Matrix4.CreateTranslation(Position);
            
            if (Parent != null)
                return  localMatrix * Parent.ModelMatrix.Value;

            return localMatrix;
        }
    }
}