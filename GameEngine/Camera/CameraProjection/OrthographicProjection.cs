using OpenTK.Mathematics;

public class OrthographicProjection : CameraProjection
{
    [EditorField] private float _size = 7;
    private readonly float _zoomingSpeed = 40f;

    public void Zoom(float delta)
    {
        _size += delta * _zoomingSpeed;
    }

    public override Matrix4 Value =>
        Matrix4.CreateOrthographic(Viewport.AspectRatio * _size, _size, NearClipPlane, FarClipPlane);
}