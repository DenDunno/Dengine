
using OpenTK.Mathematics;

public class TextureBatchingScene : IWorldFactory
{
    public List<GameObject> CreateGameObjects(PlayerInput playerInput)
    {
        Camera camera = new();
        Texture texture = new(Paths.GetTexture("tiles.png"));
        texture.Load();
        
        MeshData quad1 = new QuadMeshData(1f).GetMeshData();
        MeshData quad2 = new QuadMeshData(1f, new Vector3(1, 1, 0)).GetMeshData();

        quad1.TextureCoordinates = SubTexture.FromLocationSize(texture, Vector2.Zero, 32);
        quad2.TextureCoordinates = SubTexture.FromLocationSize(texture, new Vector2(32, 0), 32);
        
        MeshData meshData = StaticBatching.Concatenate(new[]
        {
            quad1,
            quad2
        });

        Transform transform = new();
        return new List<GameObject>()
        {
            GameObjectFactory.CreateCamera(camera),
            GameObjectFactory.CreateSkybox("Storm", camera),
            new(new GameObjectData("Map", transform)
            {
                Model = new Model(new RenderData()
                {
                    Mesh = MeshBuilder.BuildMesh(meshData),
                    Material = new UnlitMaterial(Paths.GetTexture("tiles.png")),
                    Transform = transform
                })
            })
        };
    }
}