using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public abstract class CameraProjection
{
    [EditorField] protected readonly float NearClipPlane = 0.01f;
    [EditorField] protected readonly float FarClipPlane = 10000f;
    private readonly int[] _viewport = new int[4];

    public Matrix4 Value
    {
        get
        {
            GL.GetInteger(GetPName.Viewport, _viewport);
            float aspectRatio = (float)_viewport[2] / _viewport[3];

            return GetProjectionMatrix(aspectRatio);
        }
    }

    protected abstract Matrix4 GetProjectionMatrix(float aspectRatio);
}