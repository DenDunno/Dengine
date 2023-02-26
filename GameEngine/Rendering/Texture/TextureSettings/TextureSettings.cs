using OpenTK.Graphics.OpenGL;

public class TextureSettings
{
    public readonly TextureTarget TextureTarget;
    private readonly GenerateMipmapTarget _mipmapTarget;
    private readonly TexParameter[] _parameters;

    public TextureSettings(TextureTarget textureTarget, GenerateMipmapTarget mipmapTarget, TexParameter[] parameters)
    {
        TextureTarget = textureTarget;
        _parameters = parameters;
        _mipmapTarget = mipmapTarget;
    }

    public void Apply()
    {
        foreach (TexParameter texParameter in _parameters)
        {
            texParameter.Enable();
        }
        
        GL.GenerateMipmap(_mipmapTarget);
    }
}