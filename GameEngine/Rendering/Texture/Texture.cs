using OpenTK.Graphics.OpenGL;

public class Texture : GLObject, IDisposable
{
    private readonly TextureSettings _settings;
    private readonly ITextureSource _source;
    
    protected Texture(TextureSettings settings, ITextureSource source) : base(GL.GenTexture())
    {
        _settings = settings;
        _source = source;
    }

    public void Bind(TextureUnit unit = TextureUnit.Texture0)
    {
        GL.ActiveTexture(unit);
        GL.BindTexture(_settings.TextureTarget, Id);
    }

    public void Load()
    {
        Bind();
        _source.Load();
        _settings.Apply();
    }

    public void Dispose()
    {
        GL.DeleteTexture(Id);
    }
}