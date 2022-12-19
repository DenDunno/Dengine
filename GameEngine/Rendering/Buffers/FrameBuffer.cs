using OpenTK.Graphics.OpenGL;

public class FrameBuffer
{
    private readonly int _id;
    
    public FrameBuffer()
    {
        _id = GL.GenFramebuffer();
    }

    public void Bind()
    {
        GL.BindFramebuffer(FramebufferTarget.Framebuffer, _id);
    }
}