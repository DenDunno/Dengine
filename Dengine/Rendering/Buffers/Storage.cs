using OpenTK.Graphics.OpenGL;

public abstract class Storage<T> : Buffer<T> where T : unmanaged
{
    private readonly BufferRangeTarget _bufferRangeTarget;

    protected Storage(BufferTarget bufferTarget, BufferRangeTarget bufferRangeTarget) : base(BufferUsageHint.DynamicCopy, bufferTarget, Array.Empty<T>())
    {
        _bufferRangeTarget = bufferRangeTarget;
    }
    
    public void BindToPoint(int bindingPoint)
    {
        GL.BindBufferBase(_bufferRangeTarget, bindingPoint, Id);
    }
}