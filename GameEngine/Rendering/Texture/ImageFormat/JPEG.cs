using OpenTK.Graphics.OpenGL;
using StbImageSharp;

public class JPEG : IImageFormat
{
    public ColorComponents ColorComponent => ColorComponents.RedGreenBlue;
    public PixelInternalFormat PixelInternalFormat => PixelInternalFormat.Rgb;
    public PixelFormat PixelFormat => PixelFormat.Rgb;
}