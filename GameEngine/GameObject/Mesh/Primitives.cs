using OpenTK.Mathematics;

public static class Primitives
{
    public static Mesh Cube(float size)
    {
        Vector3[] positions = 
        {
            // front
            new(size, size, -size),
            new(size, -size, -size),
            new(-size, -size, -size),
            new(-size, size, -size),

            //back
            new(size, size, size),
            new(size, -size, size),
            new(-size, -size, size),
            new(-size, size, size),
            
            //left
            new(-size, size, -size),
            new(-size, -size, -size),
            new(-size, -size, size),
            new(-size, size, size),
            
            //right
            new(size, size, -size),
            new(size, -size, -size),
            new(size, -size, size),
            new(size, size, size),
            
            //up
            new(size, size, size),
            new(size, size, -size),
            new(-size, size, -size),
            new(-size, size, size),
            
            //down
            new(size, -size, size),
            new(size, -size, -size),
            new(-size, -size, -size),
            new(-size, -size, size),
        };

        uint[] indices = 
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
        };

        Mesh mesh = new(positions, indices)
        {
            TextureCoordinates = new Vector2[]
            {
                new(1, 1),
                new(1, 0),
                new(0, 0),
                new(0, 1),

                new(1, 1),
                new(1, 0),
                new(0, 0),
                new(0, 1),

                new(1, 1),
                new(1, 0),
                new(0, 0),
                new(0, 1),

                new(1, 1),
                new(1, 0),
                new(0, 0),
                new(0, 1),

                new(1, 1),
                new(1, 0),
                new(0, 0),
                new(0, 1),

                new(1, 1),
                new(1, 0),
                new(0, 0),
                new(0, 1),
            },

            Normals = new Vector3[]
            {
                new(0, 0, -1),
                new(0, 0, -1),
                new(0, 0, -1),
                new(0, 0, -1),

                new(0, 0, 1),
                new(0, 0, 1),
                new(0, 0, 1),
                new(0, 0, 1),

                new(-1, 0, 0),
                new(-1, 0, 0),
                new(-1, 0, 0),
                new(-1, 0, 0),

                new(1, 0, 0),
                new(1, 0, 0),
                new(1, 0, 0),
                new(1, 0, 0),

                new(0, 1, 0),
                new(0, 1, 0),
                new(0, 1, 0),
                new(0, 1, 0),

                new(0, -1, 0),
                new(0, -1, 0),
                new(0, -1, 0),
                new(0, -1, 0),
            }
        };
        
        mesh.Init();
        return mesh;
    }
    
    public static Mesh Quad(float size)
    {
        Vector3[] positions = 
        {
            new(size, size, 0.0f),
            new(size, -size, 0.0f),
            new(-size, -size, 0.0f),
            new(-size, size, 0.0f),
        };

        uint[] indices = 
        {
            0, 1, 3,
            1, 2, 3,
        };

        Mesh mesh = new(positions, indices)
        {
            Normals = new Vector3[]
            {
                new(1, 0, 0),
                new(0, -1, 0),
                new(-1, 0, 0),
                new(0, 1, 0),
            }
        };
        mesh.Init();
        return mesh;
    }
}