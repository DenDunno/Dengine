using OpenTK.Graphics.OpenGL4;

public class IndexBufferObject : Buffer<uint>
{
    public IndexBufferObject(uint[] data, OpenTK.Graphics.OpenGL4.BufferUsageHint bufferUsageHint) 
        : base(bufferUsageHint, BufferTarget.ElementArrayBuffer, sizeof(uint), data)
    {
    }
}