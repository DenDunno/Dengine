using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class Demo3DFactory : WorldFactory
{
    public Demo3DFactory(Window window) : base(window)
    {
    }

    protected override List<GameObject> CreateGameObjects()
    {
        return new List<GameObject>()
        {
            CreateSkybox(),
            CreateCube(new Vector3(-2, 2, 0), true),
            CreateCube(new Vector3(2, 2, 0), false),
        };
    }
    
    private GameObject CreateCube(Vector3 position, bool isControlling)
    {
        Mesh mesh = Primitives.Cube(0.5f);
        LightData lightData = new(new Vector3(1, 0, 0), new Texture("Resources/crate.png"), new Vector3(-4, 3, -3));
        Transform transform = new(position);
        ColorShaderProgram shaderProgram = new("Shaders/vert.glsl", "Shaders/uv.glsl");
        MeshWorldView meshWorldView = new(transform, mesh);
        RenderData renderData = new()
        {
            Transform = transform,
            Mesh = mesh,
            BufferUsageHint = BufferUsageHint.StaticDraw,
            ShaderProgram = shaderProgram
        };

        AddRigidbody(new Rigidbody(transform, meshWorldView)
        {
            ColorShaderProgram = shaderProgram
        });

        return new GameObject(new GameObjectData()
        {
            Model = new Model(renderData),
            Components = GetComponents(isControlling, transform)
        });
    }
    
    private IUpdatable[] GetComponents(bool isControlling, Transform transform)
    {
        List<IUpdatable> components = new();
        
        if (isControlling)
        {
            components.Add(new ObjectControlling(transform, KeyboardState));
        }

        return components.ToArray();
    }
    
    private GameObject CreateSkybox()
    {
        Transform transform = new();
        List<string> paths = new()
        {
            "Resources/Storm/right.jpg",
            "Resources/Storm/left.jpg",
            "Resources/Storm/top.jpg",
            "Resources/Storm/bottom.jpg",
            "Resources/Storm/back.jpg",
            "Resources/Storm/front.jpg",   
        };
        RenderData renderData = new()
        {
            Transform = transform,
            Mesh = Primitives.Cube(50f),
            BufferUsageHint = BufferUsageHint.StaticDraw,
            ShaderProgram = new ShaderProgramWithTexture(new Cubemap(paths), "Shaders/skyboxVert.glsl", "Shaders/skyboxFrag.glsl"),
        };

        return new GameObject(new GameObjectData()
        {
            Model = new Model(renderData),
            Components = new IUpdatable[]
            {
                new Skybox(Camera, transform)
            },
        });
    }
}