using OpenTK.Graphics.OpenGL;

public class ShaderStorageBuffer<T> : Buffer<T> where T : unmanaged
{
    public ShaderStorageBuffer() : base(BufferUsageHint.DynamicCopy, BufferTarget.ShaderStorageBuffer, Array.Empty<T>())
    {
    }
}