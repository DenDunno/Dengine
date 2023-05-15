using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class RawTextureSource : ITextureSource
{
    private byte[] _data = Array.Empty<byte>();
    private Vector2i _size;

    public void SetData(byte[] data, Vector2i size)
    {
        _data = data;
        _size = size;
    }
    
    public void Load()
    {
        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, _size.X, _size.Y, 0, PixelFormat.Rgba, PixelType.UnsignedByte, _data);
    }
}