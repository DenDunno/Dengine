using OpenTK.Graphics.OpenGL;

public class ObjPreviewWorld : WorldFactory
{
    public ObjPreviewWorld(PlayerInput playerInput) : base(playerInput)
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
        Mesh mesh = MeshBuilder.FromObj("Models/cottage_obj.obj");
        Transform transform = new();
        MaterialWithTexture material = new(new Texture("Resources/cottage_diffuse.png"), "Shaders/vert.glsl", "Shaders/frag.glsl");
        RenderData renderData = new()
        {
            Transform = transform,
            Mesh = mesh,
            BufferUsageHint = BufferUsageHint.StaticDraw,
            Material = material
        };

        NormalsViewer.Add(transform, mesh);
        
        return new GameObject(new GameObjectData("Model", transform)
        {
            Model = new Model(renderData),
        });
    }
}