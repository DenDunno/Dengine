using OpenTK.Graphics.OpenGL;

public class Framebuffer
{
    public static int FramebufferTexture;
    private int _fbo;
    private int _depthTexture;
    private int _width = 1536;
    private int _height = 864;

    public void Initialize()
    {
        GL.DeleteFramebuffer(_fbo);
        GL.DeleteTexture(FramebufferTexture);
        GL.DeleteTexture(_depthTexture);
        
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
        int id = PlayMode.IsActive && ControlPanel.IsFullscreen ? 0 : _fbo;
        Bind(id);
    }

    private void Bind(int id)
    {
        GL.BindFramebuffer(FramebufferTarget.Framebuffer, id);
    }

    public void Resize(int width, int height)
    {
        Console.WriteLine($"Frame buffer was resized to {width}, {height}");
        
        _width = width;
        _height = height;
        Initialize();
    }
}