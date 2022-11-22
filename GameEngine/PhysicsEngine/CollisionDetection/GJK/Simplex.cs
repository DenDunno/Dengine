using OpenTK.Mathematics;

public class Simplex
{
    public Vector3 A;
    public Vector3 B;
    public Vector3 C;
    private readonly Vector3 _origin = Vector3.Zero;

    public bool IsOriginInside()
    {
        return false;
    }
}