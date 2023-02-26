using OpenTK.Mathematics;

public class StaticBatchingDemo : IWorldFactory
{
    public List<GameObject> CreateGameObjects()
    {
        return new List<GameObject>()
        {
            GameObjectFactory.CreateCamera(),
            CreatePreviewObject(),
        };
    }

    private GameObject CreatePreviewObject()
    {
        Mesh[] meshes = 
        {
            new MeshFromObj(Paths.GetModel("monkey"), new Vector3(-3, 3, 0)).Build(),
            new MeshFromObj(Paths.GetModel("house"), new Vector3(0, 0, 0)).Build(),
            new MeshFromObj(Paths.GetModel("rock"), new Vector3(3, 3, 0)).Build()
        };

        for (int i = 0; i < meshes.Length; ++i)
        {
            meshes[i].PushID("TextureId", 3, i);
        }
            
        return GameObjectFactory.WithRenderData(new RenderData()
        {
            Transform = new Transform(new Vector3(0, -3, 5)),
            Material = new Material(Paths.GetShader("Batching/vert"), Paths.GetShader("Batching/frag")),
            Mesh = StaticBatching.Concatenate(meshes)
        });
    }
}