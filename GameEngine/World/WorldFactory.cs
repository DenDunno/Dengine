using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

public class WorldFactory
{
    public IModel[] Create()
    {
        var cubeFlat = new FlatModel(new RenderData
        {
            Transform = new Transform(new Vector3(-0.8f, 0, -1.25f)),
            AttributePointers = new[]
            {
                new AttributePointer(0, 3, 8, 0),
                new AttributePointer(1, 2, 8, 3),
                new AttributePointer(2, 3, 8, 5)
            },
            Mesh = Primitives.Cube(0.5f),
            ShaderProgram = new ShaderProgram(new Shader[]
            {
                new("Shaders/vert.glsl", ShaderType.VertexShader),
                new("Shaders/colorFrag.glsl", ShaderType.FragmentShader)
            })
        });

        var cubeTexture = new ModelWithTexture(new FlatModel(new RenderData
        {
            Transform = new Transform(new Vector3(0.8f, 0, -1.25f)),
            AttributePointers = new[]
            {
                new AttributePointer(0, 3, 8, 0),
                new AttributePointer(1, 2, 8, 3),
                new AttributePointer(2, 3, 8, 5)
            },
            Mesh = Primitives.Cube(0.5f),
            ShaderProgram = new ShaderProgram(new Shader[]
            {
                new("Shaders/vert.glsl", ShaderType.VertexShader),
                new("Shaders/frag.glsl", ShaderType.FragmentShader)
            })
        }), new Texture("Resources/wood.png"));


        return new IModel[] {cubeFlat, cubeTexture};
    }
}