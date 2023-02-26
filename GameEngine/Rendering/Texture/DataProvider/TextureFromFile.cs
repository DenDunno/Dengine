using OpenTK.Graphics.OpenGL;
using StbImageSharp;

public class TextureFromFile : ITextureDataProvider
{
    private readonly string _path;
    private readonly TextureTarget _target;
    private readonly IImageFormat _imageFormat;

    public TextureFromFile(string path, IImageFormat imageFormat, TextureTarget target = TextureTarget.Texture2D)
    {
        _path = path;
        _target = target;
        _imageFormat = imageFormat;
    }
    
    public void Load()
    {
        using Stream stream = File.OpenRead(_path);
        
        ImageResult image = ImageResult.FromStream(stream, _imageFormat.ColorComponent); 
        GL.TexImage2D(_target, 0, _imageFormat.PixelInternalFormat, image.Width, image.Height, 0, _imageFormat.PixelFormat, PixelType.UnsignedByte, image.Data);
    }
}