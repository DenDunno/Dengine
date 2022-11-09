
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class ObjPreviewWorld : WorldFactory
{
    public ObjPreviewWorld(Window window) : base(window)
    {
    }

    protected override List<GameObject> CreateGameObjects()
    {
        return new List<GameObject>()
        {
            CreateModel(),
        };
    }
    
    private GameObject CreateModel()
    {
        MeshBuilder meshBuilder = new(new MeshFromObj("Models/monkey.obj"));
        Mesh mesh = meshBuilder.Build();
        LightData lightData = new(new Vector3(1, 0, 0), new Texture("Resources/crate.png"), new Vector3(-4, 3, -3));
        Transform transform = new();
        LightningShaderProgram shaderProgram = new(lightData, Camera, "Shaders/vert.glsl", "Shaders/lightning.glsl");
        MeshWorldView meshWorldView = new(transform, mesh);
        RenderData renderData = new()
        {
            Transform = transform,
            Mesh = mesh,
            BufferUsageHint = BufferUsageHint.StaticDraw,
            ShaderProgram = shaderProgram
        };

        NormalsViewer.Add(transform, mesh);
        
        return new GameObject(new GameObjectData("Model")
        {
            Model = new Model(renderData),
        });
    }
}