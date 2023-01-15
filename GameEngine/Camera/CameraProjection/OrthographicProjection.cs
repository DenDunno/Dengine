using OpenTK.Mathematics;

public class OrthographicProjection : CameraProjection
{
    [EditorField] private float _size = 7;
    private readonly float _zoomingSpeed = 40f;

    public void Zoom(float delta)
    {
        _size += delta * _zoomingSpeed;
    }

    protected override Matrix4 GetProjectionMatrix(float aspectRatio)
    {
        return Matrix4.CreateOrthographic(aspectRatio * _size, _size, NearClipPlane, FarClipPlane);
    }
}