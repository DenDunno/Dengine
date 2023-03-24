
public class DengineCompability
{
    private readonly OpenGLCompability _openGLCompability = new();

    public void Check()
    {
        _openGLCompability.ThrowIfExtensionNotAvailable("GL_ARB_direct_state_access", 4.5);
        _openGLCompability.ThrowIfExtensionNotAvailable("GL_ARB_buffer_storage", 4.4);
    }
}