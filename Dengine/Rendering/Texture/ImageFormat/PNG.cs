using OpenTK.Graphics.OpenGL;
using StbImageSharp;

public class PNG : IImageFormat
{
    public ColorComponents ColorComponent => ColorComponents.RedGreenBlueAlpha;
    public PixelInternalFormat PixelInternalFormat => PixelInternalFormat.Rgba;
    public PixelFormat PixelFormat => PixelFormat.Rgba;
}