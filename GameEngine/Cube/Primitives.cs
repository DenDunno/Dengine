
public static class Primitives
{
    public static Mesh Cube(float size)
    {
        return new Mesh()
        {
             VerticesData = new[]
             {
                  // Position          Texture       Normal
                  // front
                  size,  size, -size,  1.0f,  1.0f,  0.0f,  0.0f, -1.0f,
                  size, -size, -size,  1.0f,  0.0f,  0.0f,  0.0f, -1.0f,
                 -size, -size, -size,  0.0f,  0.0f,  0.0f,  0.0f, -1.0f,
                 -size,  size, -size,  0.0f,  1.0f,  0.0f,  0.0f, -1.0f,
                 
                  //back
                  size,  size,  size,  1.0f,  1.0f,  0.0f,  0.0f,  1.0f,
                  size, -size,  size,  1.0f,  0.0f,  0.0f,  0.0f,  1.0f,
                 -size, -size,  size,  0.0f,  0.0f,  0.0f,  0.0f,  1.0f,
                 -size,  size,  size,  0.0f,  1.0f,  0.0f,  0.0f,  1.0f,
                 
                  //left
                 -size,  size, -size,  1.0f,  1.0f, -1.0f,  0.0f,  0.0f,
                 -size, -size, -size,  1.0f,  0.0f, -1.0f,  0.0f,  0.0f, 
                 -size, -size,  size,  0.0f,  0.0f, -1.0f,  0.0f,  0.0f,
                 -size,  size,  size,  0.0f,  1.0f, -1.0f,  0.0f,  0.0f,
                 
                  //right
                  size,  size, -size,  1.0f,  1.0f,  1.0f,  0.0f,  0.0f,
                  size, -size, -size,  1.0f,  0.0f,  1.0f,  0.0f,  0.0f,
                  size, -size,  size,  0.0f,  0.0f,  1.0f,  0.0f,  0.0f,
                  size,  size,  size,  0.0f,  1.0f,  1.0f,  0.0f,  0.0f,
                 
                  //up
                  size,  size,  size,  1.0f,  1.0f,  0.0f,  1.0f,  0.0f,
                  size,  size, -size,  1.0f,  0.0f,  0.0f,  1.0f,  0.0f, 
                 -size,  size, -size,  0.0f,  0.0f,  0.0f,  1.0f,  0.0f,
                 -size,  size,  size,  0.0f,  1.0f,  0.0f,  1.0f,  0.0f,
                 
                  //down
                  size, -size,  size,  1.0f,  1.0f,  0.0f, -1.0f,  0.0f,
                  size, -size, -size,  1.0f,  0.0f,  0.0f, -1.0f,  0.0f,
                 -size, -size, -size,  0.0f,  0.0f,  0.0f, -1.0f,  0.0f,
                 -size, -size,  size,  0.0f,  1.0f,  0.0f, -1.0f,  0.0f,
             },
             
             Indices = new uint[]
             {
                 0, 1, 3,
                 1, 2, 3,
        
                 4, 5, 7,
                 5, 6, 7,
                 
                 8, 9, 11,
                 9, 10, 11,
                 
                 12, 13, 15,
                 13, 14, 15,
                 
                 16, 17, 19,
                 17, 18, 19,
                 
                 20, 21, 23,
                 21, 22, 23
             }
        };
    }
}