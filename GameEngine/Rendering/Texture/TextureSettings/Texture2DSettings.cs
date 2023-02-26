using OpenTK.Graphics.OpenGL;

public class Texture2DSettings : TextureSettings
{
    public Texture2DSettings() : base(TextureTarget.Texture2D, GenerateMipmapTarget.Texture2D, new TexParameter[]
    {
        new(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.LinearMipmapNearest),
        new(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest),
        new(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat),
        new(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat),
    })
    {
    }
}