using OpenTK.Graphics.OpenGL;

public class ElementBufferObject : Buffer<uint>
{
    public ElementBufferObject(uint[] data) 
        : base(BufferUsageHint.StaticDraw, BufferTarget.ElementArrayBuffer, sizeof(uint), data)
    {
    }
}