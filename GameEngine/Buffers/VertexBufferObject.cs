using OpenTK.Graphics.OpenGL;

public class VertexBufferObject : IDisposable
{
    private readonly float[] _vertices;
    private readonly BufferUsageHint _bufferUsageHint;
    private readonly int _id;

    public VertexBufferObject(float[] vertices, BufferUsageHint bufferUsageHint)
    {
        _vertices = vertices;
        _bufferUsageHint = bufferUsageHint;
        _id = GL.GenBuffer();
    }

    public void Bind()
    {
        GL.BindBuffer(BufferTarget.ArrayBuffer, _id);
    }

    public void SendData()
    {
        GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, _bufferUsageHint);
    }

    public void Dispose()
    {
        GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        GL.DeleteBuffer(_id);
    }
}