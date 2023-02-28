using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class Texture2DData
{
    private readonly int _id;

    public Texture2DData(int id)
    {
        _id = id;
    }
    
    public Vector2i Size
    {
        get
        {
            GL.BindTexture(TextureTarget.Texture2D, _id);
            GL.GetTexLevelParameter(TextureTarget.Texture2D, 0, GetTextureParameter.TextureWidth, out int width);
            GL.GetTexLevelParameter(TextureTarget.Texture2D, 0, GetTextureParameter.TextureHeight, out int height);

            return new Vector2i(width, height);
        }
    }

    public byte[] RawData
    {
        get
        {
            Vector2i size = Size;
            byte[] textureData = new byte[size.X * size.Y * 4];
            GL.GetTexImage(TextureTarget.Texture2D, 0, PixelFormat.Rgba, PixelType.UnsignedByte, textureData);

            return textureData;
        }
    }    
}