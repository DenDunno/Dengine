using OpenTK.Mathematics;

public abstract class CameraProjection
{
    [EditorField] protected readonly float NearClipPlane = 0.01f;
    [EditorField] protected readonly float FarClipPlane = 100000f;

    public abstract Matrix4 Value { get; }
}