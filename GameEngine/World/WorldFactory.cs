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
        var camera = new Camera(Vector3.UnitZ * 3);
        var cameraControlling = new CameraControlling(camera, _window.MouseState, _window.KeyboardState);
        
        var flatCubeTransform = new Transform(new Vector3(1.5f, 0, 0));
        var textureCubeTransform = new Transform(new Vector3(-1.5f, 0, 0));

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
        var flatCubeAnimation = new CubeAnimation(flatCubeTransform, new Vector3(0, 1, 0));
        var textureCubeAnimation = new CubeAnimation(textureCubeTransform, new Vector3(0, -1, 0));
        
        var gameObjects = new List<GameObject>()
        {
            new(new IUpdatable[] {timer, cameraControlling}),
            new(new IUpdatable[] {flatCubeAnimation}, flatCubeModel),
            new(new IUpdatable[] {textureCubeAnimation}, textureCubeModel),
        };
        
        return new World(gameObjects, camera);
    }
}