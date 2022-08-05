using OpenTK.Graphics.OpenGL;

public class IndexBufferObject : Buffer<uint>
{
    public IndexBufferObject(uint[] data) 
        : base(BufferUsageHint.StaticDraw, BufferTarget.ElementArrayBuffer, sizeof(uint), data)
    {
    }
}