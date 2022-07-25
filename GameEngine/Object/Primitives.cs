using OpenTK.Mathematics;

public static class Primitives
{
    public static Object Triangle => new(new Mesh(new[]
    {
        new Vector3(-0.5f, -0.5f, 0.0f), 
        new Vector3(0.5f, -0.5f, 0.0f),
        new Vector3(0.0f,  0.5f, 0.0f)
    }));
}