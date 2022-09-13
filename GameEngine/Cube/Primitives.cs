
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
    
    public static Mesh Quad(float size)
    {
        return new Mesh()
        {
             VerticesData = new[]
             {
                  // Position          Texture       Normal
                  size,  0.0f,  size,  1.0f,  1.0f,  0.0f,  0.0f,  0.0f,
                  size,  0.0f, -size,  1.0f,  0.0f,  0.0f,  0.0f,  0.0f, 
                 -size,  0.0f, -size,  0.0f,  0.0f,  0.0f,  0.0f,  0.0f,
                 -size,  0.0f,  size,  0.0f,  1.0f,  0.0f,  0.0f,  0.0f,
             },
             
             Indices = new uint[]
             {
                 0, 1, 3,
                 1, 2, 3,
             }
        };
    }

    public static Mesh Plane(int size)
    {
        float actualSize = size / 2f;
        
        if (actualSize <= 0)
            throw new Exception("Plane must have positive size");
        
        var vertices = new List<float>();
        var indices = new List<uint>();

        uint index = 0;
        for (float i = actualSize; i > -actualSize; --i)
        {
            for (float j = -actualSize; j < actualSize; ++j, index += 4)
            {
                vertices.AddRange(new[] {j + 1f,   i,  0,  1.0f,  1.0f,  0.0f,  0.0f,  0.0f});
                vertices.AddRange(new[] {j + 1f,  i - 1f,  0,  1.0f,  0.0f,  0.0f,  0.0f,  0.0f});
                vertices.AddRange(new[] {j,  i - 1f,  0,  0.0f,  0.0f,  0.0f,  0.0f,  0.0f});
                vertices.AddRange(new[] {j,  i,  0,  0.0f,  1.0f,  0.0f,  0.0f,  0.0f});
                
                indices.Add(index + 0);
                indices.Add(index + 1);
                indices.Add(index + 3);
                indices.Add(index + 1);
                indices.Add(index + 2);
                indices.Add(index + 3);
            }
        }

        return new Mesh()
        {
            VerticesData = vertices.ToArray(),
            Indices = indices.ToArray()
        };
    }
}