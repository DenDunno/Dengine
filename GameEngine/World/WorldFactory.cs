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
        var cameraGameObject = new GameObject(new IUpdatable[] {timer, cameraControlling});
        
        return new World(camera, new List<GameObject>()
        {
            cameraGameObject,
            CreateFlatCube(),
            CreateCubeWithTexture(),
            CreatePlane(),
            CreateSkybox(camera)
        });
    }

    private GameObject CreateSkybox(Camera camera)
    {
        var transform = new Transform(new Vector3(0, 0, 0));
        var renderData = new RenderData(transform, Primitives.Cube(50f), new[]
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
        
        var model = new ModelWithTexture(new FlatModel(renderData, BufferUsageHint.DynamicDraw), new Texture("Resources/wood.png"));
        var skybox = new Skybox(camera, transform);

        return new GameObject(new IUpdatable[]{skybox}, model);
    }

    private GameObject CreatePlane()
    {
        var renderData = new RenderData(new Transform(new Vector3(0, -1f, 0)), Primitives.Plane(5f), new[]
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

        return new GameObject(new ModelWithTexture(
            new FlatModel(renderData, BufferUsageHint.DynamicDraw), new Texture("Resources/Grass/Base.png")));
    }

    private GameObject CreateCubeWithTexture()
    {
        var transform = new Transform(new Vector3(-1.5f, 0, 0));
        var renderData = new RenderData(transform, Primitives.Cube(0.5f), new[]
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
        
        var model = new ModelWithTexture(new FlatModel(renderData, BufferUsageHint.DynamicDraw), new Texture("Resources/wood.png"));
        var animation = new CubeAnimation(transform, new Vector3(0, -1, 0));
        
        return new GameObject(new IUpdatable[] {animation}, model);
    }
    
    private GameObject CreateFlatCube()
    {
        var transform = new Transform(new Vector3(1.5f, 0, 0));
        var renderData = new RenderData(transform, Primitives.Cube(0.5f), new[]
        {
            new AttributePointer(0, 3, 8, 0),
            new AttributePointer(1, 2, 8, 3),
        },
        new ShaderProgram(new Shader[]
        {
            new("Shaders/vert.glsl", ShaderType.VertexShader),
            new("Shaders/colliderFrag.glsl", ShaderType.FragmentShader)
        }));

        var model = new FlatModel(renderData, BufferUsageHint.DynamicDraw);
        var animation = new CubeAnimation(transform, new Vector3(0, 1, 0));
        
        return new GameObject(new IUpdatable[] {animation}, model);
    }
}