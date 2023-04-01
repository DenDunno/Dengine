using System.Drawing;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class LightUniformBuffer
{
    private readonly UniformBuffer<LightData> _uniformBuffer = new();
    [EditorField] private readonly Color _color = Color.White;
    [EditorField] private readonly float _specular = 0.75f;
    [EditorField] private readonly float _diffuse = 1.65f;
    [EditorField] private readonly float _ambient = 0.4f;
    private readonly Transform _transform;
    private LightData _data;
    
    public LightUniformBuffer(Transform transform, LightData data)
    {
        _transform = transform;
        _data = data;
    }
    
    public void Initialize()
    {
        _uniformBuffer.Bind();
        _uniformBuffer.BindToPoint(1);
        _uniformBuffer.BufferData(new LightData());
    }
    
    public unsafe void Map()
    {
        DengineConsole.Instance.Log(_data.Ambient);
        _data.Position = new Vector4(_transform.Position, 1);
        
        _uniformBuffer.Bind();
        LightData* data = _uniformBuffer.MapBuffer(BufferAccess.WriteOnly);

        data->Ambient = _ambient;
        data->Specular = _specular;
        data->Diffuse = _diffuse;
        data->Position = new Vector4(_transform.Position, 0);
        data->Color = _color.ToVector4() / 255;
        
        _uniformBuffer.UnMapBuffer();
    }

    public void Dispose()
    {
        _uniformBuffer.Dispose();
    }
}