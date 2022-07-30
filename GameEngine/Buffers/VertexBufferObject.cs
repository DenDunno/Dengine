using OpenTK.Graphics.OpenGL;

public class VertexBufferObject : Buffer<float>
{
    public VertexBufferObject(float[] data) : base(BufferUsageHint.StaticDraw, BufferTarget.ArrayBuffer, sizeof(float), data)
    {
    }
}