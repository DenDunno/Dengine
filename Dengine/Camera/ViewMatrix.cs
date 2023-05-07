using OpenTK.Mathematics;

public class ViewMatrix
{
    private readonly Transform _transform;

    public ViewMatrix(Transform transform)
    {
        _transform = transform;
    }
    
    public Matrix4 Value => Matrix4.LookAt(_transform.Position, _transform.Position + _transform.Front, _transform.Up);
}