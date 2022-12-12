using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class Demo3D : WorldFactory
{
    public Demo3D(PlayerInput playerInput) : base(playerInput)
    {
    }

    protected override List<GameObject> CreateGameObjects()
    {
        return new List<GameObject>()
        {
            CreateSkybox(),
            CreateCube("Controlling cube", new Vector3(-2, 2, 0), true, Vector3.Zero),
            CreateCube("Cube1", new Vector3(2, 2, 0), false, new Vector3(0, 45, 45)),
        };
    }
    
    private GameObject CreateCube(string name, Vector3 position, bool isControlling, Vector3 rotation)
    {
        Mesh mesh = MeshBuilder.FromObj("Models/cube.obj");
        LightData lightData = new(new Vector3(1, 0, 0), new Texture("Resources/crate.png"), new Vector3(-4, 3, -3));
        Transform transform = new(position, Quaternion.FromEulerAngles(rotation));
        LightningShaderProgram shaderProgram = new(lightData, CameraTransform, "Shaders/vert.glsl", "Shaders/lightning.glsl");
        MeshWorldView meshWorldView = new(transform, mesh);
        meshWorldView.CalculateNormals();
        
        RenderData renderData = new()
        {
            Transform = transform,
            Mesh = mesh,
            BufferUsageHint = BufferUsageHint.StaticDraw,
            ShaderProgram = shaderProgram
        };

        AddRigidbody(new Rigidbody(transform)
        {
            ShaderProgram = shaderProgram
        });

        NormalsViewer.Add(meshWorldView);
        
        return new GameObject(new GameObjectData(name, transform)
        {
            Model = new Model(renderData),
            Dependencies = GetComponents(isControlling, transform)
        });
    }
    
    private object[] GetComponents(bool isControlling, Transform transform)
    {
        List<object> components = new();

        if (isControlling)
        {
            components.Add(new ObjectControlling(transform, Input.Keyboard));
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
            Mesh = MeshBuilder.Cube(50),
            BufferUsageHint = BufferUsageHint.StaticDraw,
            ShaderProgram = new ShaderProgramWithTexture(new Cubemap(paths), "Shaders/skyboxVert.glsl", "Shaders/skyboxFrag.glsl"),
        };

        return new GameObject(new GameObjectData("Skybox", transform)
        {
            Model = new Model(renderData),
            Dependencies = new object[]
            {
                new Skybox(CameraTransform, transform),
            }
        });
    }
}