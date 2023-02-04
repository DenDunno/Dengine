using OpenTK.Graphics.OpenGL;

public class ShaderStorageBuffer<T> : Buffer<T> where T : struct
{
    public ShaderStorageBuffer(T[] data) : base(BufferUsageHint.DynamicCopy, BufferTarget.ShaderStorageBuffer, data)
    {
    }

    public void BindToPoint(int bindingPoint)
    {
        Bind();
        BufferData();
        BufferBase(bindingPoint);
        UnBind();
    }
}