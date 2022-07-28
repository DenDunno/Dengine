using OpenTK.Graphics.OpenGL;

public class ShaderProgram
{
    public readonly int Id;
    
    public ShaderProgram()
    {
        Id = GL.CreateProgram();
    }

    public void Link()
    {
        GL.LinkProgram(Id);
        Console.WriteLine(GL.GetProgramInfoLog(Id));
    }
}