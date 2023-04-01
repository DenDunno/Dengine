using OpenTK.Graphics.OpenGL;

public class LightUniformBuffer
{
    private readonly UniformBuffer<LightData> _uniformBuffer = new();

    public void Initialize()
    {
        //_uniformBuffer.
    }
    
    public unsafe void Map(ref LightData dataToCopy)
    {
        LightData* data = _uniformBuffer.MapBuffer(BufferAccess.WriteOnly);

        data->Position = dataToCopy.Position;
        data->Color = dataToCopy.Color;
        data->Specular = dataToCopy.Specular;
        data->Ambient = dataToCopy.Ambient;
        data->Diffuse = dataToCopy.Diffuse;
        
        _uniformBuffer.UnMapBuffer();
    }
    
    
}