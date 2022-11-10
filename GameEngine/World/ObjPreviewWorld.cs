using OpenTK.Graphics.OpenGL;

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
        MeshBuilder meshBuilder = new(new MeshFromObj("Models/cottage_obj.obj"));
        Mesh mesh = meshBuilder.Build();
        Transform transform = new();
        ShaderProgramWithTexture shaderProgram = new(new Texture("Resources/cottage_diffuse.png"), "Shaders/vert.glsl", "Shaders/frag.glsl");
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