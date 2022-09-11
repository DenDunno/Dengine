using OpenTK.Graphics.OpenGL4;

public abstract class TextureBase
{
    private readonly TextureTarget _textureTarget;
    private readonly int _id;

    protected TextureBase(TextureTarget textureTarget)
    {
        _textureTarget = textureTarget;
        _id = GL.GenTexture();
    }

    public void Use(TextureUnit unit = TextureUnit.Texture0)
    {
        GL.ActiveTexture(unit);
        GL.BindTexture(_textureTarget, _id);
    }

    public abstract void Load();
}