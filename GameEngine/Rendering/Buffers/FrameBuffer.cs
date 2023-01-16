using OpenTK.Graphics.OpenGL;

public class Framebuffer : Singlton<Framebuffer>
{
    public int FramebufferTexture;
    private int _fbo;
    private int _depthTexture;
    private readonly int _width = 1536;
    private readonly int _height = 864;

    public void Init()
    {
        GL.CreateFramebuffers(1, out _fbo);
        GL.BindFramebuffer(FramebufferTarget.Framebuffer, _fbo);
        
        GL.CreateTextures(TextureTarget.Texture2D, 1, out FramebufferTexture);
        GL.BindTexture(TextureTarget.Texture2D, FramebufferTexture);
        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba8, _width, _height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, IntPtr.Zero);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMagFilter.Linear);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
        
        GL.FramebufferTexture2D(FramebufferTarget.Framebuffer, FramebufferAttachment.ColorAttachment0, TextureTarget.Texture2D, FramebufferTexture, 0);
        
        GL.CreateTextures(TextureTarget.Texture2D, 1, out _depthTexture);
        GL.BindTexture(TextureTarget.Texture2D, _depthTexture);
        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Depth24Stencil8, _width, _height, 0, PixelFormat.DepthStencil, PixelType.UnsignedInt248, IntPtr.Zero);
        
        GL.FramebufferTexture2D(FramebufferTarget.Framebuffer, FramebufferAttachment.DepthStencilAttachment, TextureTarget.Texture2D, _depthTexture, 0);
        
        GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
    }

    public void Bind()
    {
        Bind(_fbo);
    }

    public void UnBind()
    {
        Bind(0);
    }

    private void Bind(int id)
    {
        GL.BindFramebuffer(FramebufferTarget.Framebuffer, id);
    }
}