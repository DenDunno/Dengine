using OpenTK.Graphics.OpenGL;
using StbImageSharp;

public interface IImageFormat
{
    ColorComponents ColorComponent { get; }
    PixelInternalFormat PixelInternalFormat { get; }
    PixelFormat PixelFormat { get; }
}