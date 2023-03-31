using OpenTK.Graphics.OpenGL;

public class ShaderStorageBuffer<T> : Storage<T> where T : unmanaged
{
    public ShaderStorageBuffer() : base(BufferTarget.ShaderStorageBuffer, BufferRangeTarget.ShaderStorageBuffer)
    {
    }
}