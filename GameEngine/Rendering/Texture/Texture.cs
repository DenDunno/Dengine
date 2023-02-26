using OpenTK.Graphics.OpenGL;

public class Texture : GLObject, IDisposable
{
    private readonly TextureSettings _settings;
    private readonly ITextureDataProvider _dataProvider;
    
    protected Texture(TextureSettings settings, ITextureDataProvider dataProvider) : base(GL.GenTexture())
    {
        _settings = settings;
        _dataProvider = dataProvider;
    }

    public void Bind(TextureUnit unit = TextureUnit.Texture0)
    {
        GL.ActiveTexture(unit);
        GL.BindTexture(_settings.TextureTarget, Id);
    }

    public void Load()
    {
        Bind();
        _dataProvider.Load();
        _settings.Apply();
    }

    public void Dispose()
    {
        GL.DeleteTexture(Id);
    }
}