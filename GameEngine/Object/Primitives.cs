using OpenTK.Mathematics;

public static class Primitives
{
    public static Object Triangle => new(new Mesh(new[]
    {
        new Vector4(-1f, 0f, 0.0f, 1), 
        new Vector4(0f, 1f, 0.0f, 1),
        new Vector4(1f,  0f, 0.0f, 1)
    }));
}