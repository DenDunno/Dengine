using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public static class CameraExtensions
{
    public static Vector2 ScreenToWorldCoordinates(this Camera camera, Vector2 screenPosition)
    {
        Matrix4 view = camera.ViewMatrix;
        Matrix4 projection = camera.Projection.Value;
        
        int[] viewport = new int[4];
        GL.GetInteger(GetPName.Viewport, viewport);
        view[1,3] = -view[1,3];
        Vector2 viewportSize = new(viewport[2], viewport[3]);
        
        Vector2 input = new(screenPosition.X, viewport[3] - screenPosition.Y);
        
        Vector4 result = new()
        {
            X = 2.0f * input.X / viewportSize.X - 1,
            Y = 2.0f * input.Y / viewportSize.Y - 1,
            Z = 0,
            W = 1
        };

        Matrix4 viewInv = Matrix4.Invert(view);
        Matrix4 projInv = Matrix4.Invert(projection);

        Vector4.TransformRow(in result, in projInv, out result);
        Vector4.TransformRow(in result, in viewInv, out result);

        if (result.W > float.Epsilon || result.W < float.Epsilon)
        {
            result.X /= result.W;
            result.Y /= result.W;
            result.Z /= result.W;
        }

        return new Vector2(result.X, result.Y);
    }
}