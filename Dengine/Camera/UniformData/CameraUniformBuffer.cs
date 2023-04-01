using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class CameraUniformBuffer
{
    private readonly UniformBuffer<CameraUniformData> _uniformBuffer = new();
    private readonly CameraProjection _projection;
    private readonly Transform _transform;

    public CameraUniformBuffer(Transform transform, CameraProjection projection)
    {
        _transform = transform;
        _projection = projection;
    }

    public void Initialize()
    {
        _uniformBuffer.Bind();
        _uniformBuffer.BindToPoint(0);
        _uniformBuffer.BufferData(new CameraUniformData());
    }
    
    public unsafe void Update()
    {
        CameraUniformData* data = _uniformBuffer.MapBuffer(BufferAccess.WriteOnly);

        data->Position = new Vector4(_transform.Position);
        data->ViewMatrix = Matrix4.LookAt(_transform.Position, _transform.Position + _transform.Front, _transform.Up);
        data->ProjectionMatrix = _projection.Value;
        
        _uniformBuffer.UnMapBuffer();
    }

    public void Dispose()
    {
        _uniformBuffer.Dispose();
    }
}