using OpenTK.Graphics.OpenGL;

public class IndexBufferObject : Buffer<uint>
{
    public IndexBufferObject(uint[] data, BufferUsageHint bufferUsageHint) 
        : base(bufferUsageHint, BufferTarget.ElementArrayBuffer, data)
    {
    }
}