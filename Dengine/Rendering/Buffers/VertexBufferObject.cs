using OpenTK.Graphics.OpenGL;

public class VertexBufferObject : Buffer<float>
{
    public VertexBufferObject(float[] data, BufferUsageHint bufferUsageHint) 
        : base(bufferUsageHint, BufferTarget.ArrayBuffer, data)
    {
    }
}