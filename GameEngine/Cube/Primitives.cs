using OpenTK.Mathematics;

public static class Primitives
{
    public static GameObject Cube()
    {
        var cubeTransform = new Transform();
        var cubeAnimation = new CubeAnimation(cubeTransform);
        var mesh = new Mesh()
        {
            Points = new[] 
            {
                new Vector3(-0.2f, -0.2f,  -0.2f),
                new Vector3(0.2f, -0.2f,  -0.2f),
                new Vector3(0.2f, 0.2f,  -0.2f),
                new Vector3(-0.2f, 0.2f,  -0.2f),
                new Vector3(-0.2f, -0.2f,  0.2f),
                new Vector3(0.2f, -0.2f,  0.2f),
                new Vector3(0.2f, 0.2f,  0.2f),
                new Vector3(-0.2f, 0.2f,  0.2f),
            },
    
            Indices = new[]
            {
                0, 7, 3, //front
                0, 4, 7,
                1, 2, 6, //back
                6, 5, 1,
                0, 2, 1, //left
                0, 3, 2,
                4, 5, 6, //right
                6, 7, 4,
                2, 3, 6, //top
                6, 3, 7,
                0, 1, 5, //bottom
                0, 5, 4
            }
        };
        
        return new GameObject(cubeTransform, new Model(mesh, new Material()), new IUpdatable[] {cubeAnimation});
    }
}