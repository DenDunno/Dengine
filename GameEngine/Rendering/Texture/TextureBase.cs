using OpenTK.Graphics.OpenGL4;

public abstract class TextureBase
{
    private readonly TextureTarget _textureTarget;
    public readonly int Id;

    protected TextureBase(TextureTarget textureTarget)
    {
        _textureTarget = textureTarget;
        Id = GL.GenTexture();
    }

    public void Use(TextureUnit unit = TextureUnit.Texture0)
    {
        GL.ActiveTexture(unit);
        GL.BindTexture(_textureTarget, Id);
    }

    public abstract void Load();
}