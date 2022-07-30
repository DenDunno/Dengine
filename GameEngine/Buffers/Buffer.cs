using OpenTK.Graphics.OpenGL;

public abstract class Buffer<T> : IDisposable where T : struct
{
    private readonly BufferUsageHint _bufferUsageHint;
    private readonly BufferTarget _bufferTarget;
    private readonly int _typeSize;
    private readonly T[] _data;
    private readonly int _id;

    protected Buffer(BufferUsageHint bufferUsageHint, BufferTarget bufferTarget, int typeSize, T[] data)
    {
        _bufferUsageHint = bufferUsageHint;
        _bufferTarget = bufferTarget;
        _typeSize = typeSize;
        _data = data;
        _id = GL.GenBuffer();
    }

    public void Bind()
    {
        GL.BindBuffer(_bufferTarget, _id);
    }
    
    public void SendData()
    {
        GL.BufferData(_bufferTarget, _data.Length * _typeSize, _data, _bufferUsageHint);
    }
    
    public void Dispose()
    {
        GL.BindBuffer(_bufferTarget, 0);
        GL.DeleteBuffer(_id);
    }
}