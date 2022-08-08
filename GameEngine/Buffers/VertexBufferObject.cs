using OpenTK.Graphics.OpenGL4;

public class VertexBufferObject : Buffer<float>
{
    public VertexBufferObject(float[] data, BufferUsageHint bufferUsageHint) : base(bufferUsageHint, BufferTarget.ArrayBuffer, sizeof(float), data)
    {
    }
}