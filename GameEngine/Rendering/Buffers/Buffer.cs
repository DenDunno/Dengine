using System.Runtime.CompilerServices;
using OpenTK.Graphics.OpenGL;

public abstract class Buffer<T> : GLObject, IDisposable where T : unmanaged
{
    private readonly BufferUsageHint _bufferUsageHint;
    private readonly BufferTarget _bufferTarget;
    private T[] _data;

    protected Buffer(BufferUsageHint bufferUsageHint, BufferTarget bufferTarget, T[] data) : base(GL.GenBuffer())
    {
        _bufferUsageHint = bufferUsageHint;
        _bufferTarget = bufferTarget;
        _data = data;
    }

    public void SendAndRelease()
    {
        Bind();
        BufferData();
        ReleaseData();
    }

    public void Bind()
    {
        GL.BindBuffer(_bufferTarget, Id);
    }

    protected void UnBind()
    {
        GL.BindBuffer(_bufferTarget, 0);
    }

    public void BufferData()
    {
        GL.BufferData(_bufferTarget, _data.Length * Unsafe.SizeOf<T>(), _data, _bufferUsageHint);
    }
    
    public void BufferData(T[] data) 
    {
        GL.BufferData(_bufferTarget, data.Length * Unsafe.SizeOf<T>(), data, _bufferUsageHint);
    }
    
    public void AllocateMutableData(int size)
    {
        GL.BufferData(_bufferTarget, size * Unsafe.SizeOf<T>(), IntPtr.Zero, _bufferUsageHint);
    }

    public void BindToPoint(int bindingPoint)
    {
        GL.BindBufferBase(BufferRangeTarget.ShaderStorageBuffer, bindingPoint, Id);
    }

    public unsafe T* MapBuffer(BufferAccess access) 
    {
        return (T*)GL.MapBuffer(_bufferTarget, access);
    }

    public void UnMapBuffer()
    {
        GL.UnmapBuffer(_bufferTarget);
    }

    public void ReleaseData()
    {
        _data = Array.Empty<T>();
    }

    public void Dispose()
    {
        GL.BindBuffer(_bufferTarget, 0);
        GL.DeleteBuffer(Id);
    }
}