using System.Runtime.InteropServices;
using OpenTK.Graphics.OpenGL;

public class UniformData<T> where T : unmanaged
{
    private readonly UniformBuffer<T> _uniformBuffer = new();
    private readonly int _bindingPoint;

    public UniformData(int bindingPoint)
    {
        _bindingPoint = bindingPoint;
    }

    public void Initialize()
    {
        _uniformBuffer.Bind();
        _uniformBuffer.BindToPoint(_bindingPoint);
        _uniformBuffer.BufferData(new T());
    }

    public unsafe void Map(T data)
    {
        _uniformBuffer.Bind();
        T* pointer = _uniformBuffer.MapBuffer(BufferAccess.WriteOnly);
        
        Marshal.StructureToPtr(data, (nint)pointer, false);

        _uniformBuffer.UnMapBuffer();
    }

    public void Dispose()
    {
        _uniformBuffer.Dispose();
    }
}