using OpenTK.Mathematics;

public class Plane
{
    private Vector3 _normal;
    private float _distance;

    public Plane()
    {
        _normal = Vector3.Zero;
        _distance = 0.0f;
    }
    
    public Plane(Vector3 normal, float distance)
    {
        _normal = normal;
        _distance = distance;
    }
    
    public Plane(Vector4 planeEquation)
    {
        _normal = new Vector3(planeEquation.X, planeEquation.Y, planeEquation.Z);
        _distance = planeEquation.W / _normal.Length;
        _normal = Vector3.Normalize(_normal);
    }

    public void Set(Vector4 planeEquation)
    {
        _normal = new Vector3(planeEquation.X, planeEquation.Y, planeEquation.Z);
        _distance = planeEquation.W / _normal.Length;
        _normal = Vector3.Normalize(_normal);
    }

    public float DistanceTo(Vector3 point)
    {
        return Vector3.Dot(_normal, point) - _distance;
    }
}