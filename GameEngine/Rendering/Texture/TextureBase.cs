using OpenTK.Graphics.OpenGL4;

public abstract class TextureBase : GLObject, IDisposable
{
    private readonly TextureTarget _textureTarget;

    protected TextureBase(TextureTarget textureTarget) : base(GL.GenTexture())
    {
        _textureTarget = textureTarget;
    }

    public void Use(TextureUnit unit = TextureUnit.Texture0)
    {
        GL.ActiveTexture(unit);
        GL.BindTexture(_textureTarget, Id);
    }

    public abstract void Load();

    public void Dispose()
    {
        GL.DeleteTexture(Id);
    }
}