using OpenTK.Graphics.OpenGL4;

public class IndexBufferObject : Buffer<uint>
{
    public IndexBufferObject(uint[] data, BufferUsageHint bufferUsageHint) 
        : base(bufferUsageHint, BufferTarget.ElementArrayBuffer, sizeof(uint), data)
    {
    }
}