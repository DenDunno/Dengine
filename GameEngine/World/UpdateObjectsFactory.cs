using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

public class UpdateObjectsFactory
{
    private readonly Window _window;
    private readonly Camera _camera;
    private readonly List<Rigidbody> _rigidbodies = new();

    public UpdateObjectsFactory(Window window, Camera camera)
    {
        _window = window;
        _camera = camera;
    }
    
    public UpdateObjects Create()
    {
        var gameObjects = new List<GameObject>()
        {
            CreateStaticPoint(),
            CreateFlatCube(),
            CreatePlane(),
            CreateCubeWithTexture(),
            CreateSkybox(),
        };

        return new UpdateObjects(gameObjects, _rigidbodies);
    }

    private GameObject CreateStaticPoint()
    {
        return new GameObject(new GameObjectData()
        {
            Components = new IUpdatable[]
            {
                new Timer(), 
                new CameraControlling(_camera, _window.MouseState, _window.KeyboardState)
            } 
        });
    }

    private GameObject CreateSkybox()
    {
        var transform = new Transform(new Vector3(0, 0, 0));
        var paths = new List<string>()
        {
            "Resources/Storm/right.jpg",
            "Resources/Storm/left.jpg",
            "Resources/Storm/top.jpg",
            "Resources/Storm/bottom.jpg",
            "Resources/Storm/back.jpg",
            "Resources/Storm/front.jpg",   
        };
        var renderData = new RenderData(transform, Primitives.Cube(50f), new[]
        {
            new AttributePointer(0, 3, 8, 0)
        },
        new ShaderProgramWithTexture(new Cubemap(paths), new Shader[]
        {
            new("Shaders/skyboxVert.glsl", ShaderType.VertexShader),
            new("Shaders/skyboxFrag.glsl", ShaderType.FragmentShader)
        }));

        return new GameObject(new GameObjectData()
        {
            Model = new Model(renderData, BufferUsageHint.DynamicDraw),
            Components = new IUpdatable[]
            {
                new Skybox(_camera, transform)
            },
        });
    }

    private GameObject CreatePlane()
    {
        var renderData = new RenderData(new Transform(new Vector3(0, -1f, 0)), Primitives.Plane(5f), new[]
        {
            new AttributePointer(0, 3, 8, 0),
            new AttributePointer(1, 2, 8, 3),
            new AttributePointer(2, 3, 8, 5)
        },
        new ShaderProgramWithTexture(new Texture("Resources/Grass/Base.png"), new Shader[]
        {
            new("Shaders/vert.glsl", ShaderType.VertexShader),
            new("Shaders/frag.glsl", ShaderType.FragmentShader)
        }));

        return new GameObject(new GameObjectData()
        {
            Model = new Model(renderData, BufferUsageHint.StaticDraw)
        });
    }

    private GameObject CreateCubeWithTexture()
    {
        var lightData = new LightData(new Vector3(1, 0, 0), new Texture("Resources/crate.png"), new Vector3(-4, 3, -3));
        var transform = new Transform(new Vector3(-1.5f, 0, 0));
        var renderData = new RenderData(transform, Primitives.Cube(0.5f), new[]
        {
            new AttributePointer(0, 3, 8, 0),
            new AttributePointer(1, 2, 8, 3),
            new AttributePointer(2, 3, 8, 5)
        },
        new LightningShaderProgram(lightData, _camera, new Shader[]
        {
            new("Shaders/vert.glsl", ShaderType.VertexShader),
            new("Shaders/lightning.glsl", ShaderType.FragmentShader)
        }));

        return new GameObject(new GameObjectData()
        {
            Model = new Model(renderData, BufferUsageHint.DynamicDraw),
            Components = new IUpdatable[]
            {
                new CubeAnimation(transform, new Vector3(0, -1, 0))
            },
        });
    }
    
    private GameObject CreateFlatCube()
    {
        var lightData = new LightData(new Vector3(1, 0, 0), new Texture("Resources/crate.png"), new Vector3(-4, 3, -3));
        var transform = new Transform(new Vector3(1.5f, 0, 0));
        var renderData = new RenderData(transform, Primitives.Cube(0.5f), new[]
        {
            new AttributePointer(0, 3, 8, 0),
            new AttributePointer(1, 2, 8, 3),
            new AttributePointer(2, 3, 8, 5)
        },
        new LightningShaderProgram(lightData, _camera, new Shader[]
        {
            new("Shaders/vert.glsl", ShaderType.VertexShader),
            new("Shaders/lightning.glsl", ShaderType.FragmentShader)
        }));

        return new GameObject(new GameObjectData()
        {
            Model = new Model(renderData, BufferUsageHint.DynamicDraw),
            Components = new IUpdatable[]
            {
                new CubeAnimation(transform, new Vector3(0, 1, 0))
            },
        });
    }
}