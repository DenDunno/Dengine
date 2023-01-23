using OpenTK.Graphics.OpenGL4;
using StbImageSharp;

public abstract class TextureBase : GLObject, IDisposable
{
    private readonly TextureTarget _textureTarget;
    private bool _wasLoaded;
    
    protected TextureBase(TextureTarget textureTarget) : base(GL.GenTexture())
    {
        _textureTarget = textureTarget;
    }

    public void Use(TextureUnit unit = TextureUnit.Texture0)
    {
        GL.ActiveTexture(unit);
        GL.BindTexture(_textureTarget, Id);
    }

    public void Load()
    {
        if (_wasLoaded == false)
        {
            _wasLoaded = true;
            OnLoad();
        }
    }

    protected abstract void OnLoad();

    public void Dispose()
    {
        GL.DeleteTexture(Id);
    }
}