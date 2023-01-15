using OpenTK.Mathematics;

public class PerspectiveProjection : CameraProjection
{
    protected override Matrix4 GetProjectionMatrix(float aspectRatio)
    {
        return Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver2, aspectRatio, NearClipPlane, FarClipPlane);
    }
}