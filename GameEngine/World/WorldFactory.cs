using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

public class WorldFactory
{
    private readonly Window _window;

    public WorldFactory(Window window)
    {
        _window = window;
    }
    
    public World Create()
    {
        var timer = new Timer(_window);
        var camera = new Camera(_window.KeyboardState, _window.MouseState);
        
        var flatCubeTransform = new Transform(new Vector3(-1f, 0, -2.45f));
        var textureCubeTransform = new Transform(new Vector3(1f, 0, -2.45f));

        var flatCubeData = new RenderData(flatCubeTransform, Primitives.Cube(0.5f), new[]
        {
            new AttributePointer(0, 3, 8, 0),
            new AttributePointer(1, 2, 8, 3),
        },
            new ShaderProgram(new Shader[]
        {
            new("Shaders/vert.glsl", ShaderType.VertexShader),
            new("Shaders/colorFrag.glsl", ShaderType.FragmentShader)
        }));
        
        var textureCubeData = new RenderData(textureCubeTransform, Primitives.Cube(0.5f), new[]
        {
            new AttributePointer(0, 3, 8, 0),
            new AttributePointer(1, 2, 8, 3),
            new AttributePointer(2, 3, 8, 5)
        },
            new ShaderProgram(new Shader[]
        {
            new("Shaders/vert.glsl", ShaderType.VertexShader),
            new("Shaders/frag.glsl", ShaderType.FragmentShader)
        }));
        
       
        var flatCubeModel = new FlatModel(flatCubeData);
        var textureCubeModel = new ModelWithTexture(new FlatModel(textureCubeData), new Texture("Resources/wood.png"));
        var flatCubeAnimation = new CubeAnimation(flatCubeTransform);
        var textureCubeAnimation = new CubeAnimation(textureCubeTransform);
        
        var gameObjects = new List<GameObject>()
        {
            new(new IUpdatable[] {timer, camera}),
            new(new IUpdatable[] {flatCubeAnimation}, flatCubeModel),
            new(new IUpdatable[] {textureCubeAnimation}, textureCubeModel),
        };
        
        return new World(gameObjects, camera);
    }
}