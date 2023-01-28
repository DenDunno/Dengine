using OpenTK.Graphics.OpenGL;

public abstract class Buffer<T> : GLObject, IDisposable where T : struct
{
    private readonly BufferUsageHint _bufferUsageHint;
    private readonly BufferTarget _bufferTarget;
    private T[] _data;

    protected Buffer(BufferUsageHint bufferUsageHint, BufferTarget bufferTarget, T[] data) 
        : base(GL.GenBuffer())
    {
        _bufferUsageHint = bufferUsageHint;
        _bufferTarget = bufferTarget;
        _data = data;
    }

    public void SendAndRelease()
    {
        Bind();
        SendData();
        Release();
    }

    private void Bind()
    {
        GL.BindBuffer(_bufferTarget, Id);
    }

    private void SendData()
    {
        GL.BufferData(_bufferTarget, _data.Length * GenericSize.Evaluate<T>(), _data, _bufferUsageHint);
    }

    private void Release()
    {
        _data = null!;
    }

    public void Dispose()
    {
        GL.BindBuffer(_bufferTarget, 0);
        GL.DeleteBuffer(Id);
    }
}