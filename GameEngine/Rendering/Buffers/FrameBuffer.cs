using OpenTK.Graphics.OpenGL;

public class Framebuffer : GLObject
{
    public Framebuffer() : base(GL.GenFramebuffer())
    {
    }

    public void Init()
    {
        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb16f, 100, 100, 0, PixelFormat.Rgb, PixelType.UnsignedByte, IntPtr.Zero);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMinFilter.Nearest);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToEdge);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.ClampToEdge);
        
        GL.FramebufferTexture2D(FramebufferTarget.Framebuffer, FramebufferAttachment.ColorAttachment0, TextureTarget.Texture2D, Id, 0);
    }

    public void Bind()
    {
        GL.BindTexture(TextureTarget.Texture2D, Id);
    }

    protected void Dispose()
    {
        GL.DeleteFramebuffer(Id);
    }
}