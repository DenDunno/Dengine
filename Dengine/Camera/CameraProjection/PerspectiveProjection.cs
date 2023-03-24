using OpenTK.Mathematics;

public class PerspectiveProjection : CameraProjection
{
    public override Matrix4 Value =>
        Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver2, Viewport.AspectRatio, NearClipPlane, FarClipPlane);
}