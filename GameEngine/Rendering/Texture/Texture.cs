using OpenTK.Graphics.OpenGL4;
using StbImageSharp;

public class Texture : TextureBase
{
    public readonly string Path;

    public Texture(string path) : base(TextureTarget.Texture2D)
    {
        Path = path;
    }

    protected override void OnLoad()
    {
        Use();
        using (Stream stream = File.OpenRead(Path))
        {
            ImageResult image = ImageResult.FromStream(stream, ColorComponents.RedGreenBlueAlpha); 
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, image.Data);
        }

        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.LinearMipmapNearest);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
        GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
    }
}