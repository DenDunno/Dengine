using OpenTK.Graphics.OpenGL;

public class UniformBuffer<T> : Storage<T> where T : unmanaged
{
    public UniformBuffer() : base(BufferTarget.UniformBuffer, BufferRangeTarget.UniformBuffer)
    {
    }
}