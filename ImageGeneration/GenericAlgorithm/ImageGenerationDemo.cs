using System.Drawing;
using OpenTK.Mathematics;

public class ImageGenerationDemo : IWorldFactory
{
    public List<GameObject> CreateGameObjects()
    {
        Texture2D targetTexture = new(Paths.GetTexture("20x20.png"));
        Camera camera = new(new Transform(new Vector3(0, 0, 1f)), new OrthographicProjection(3), new RenderSettings()
        {
            ClearColor = Color.Bisque
        });
        
        return new List<GameObject>()
        {
            GameObjectFactory.CreateCamera(camera),
            GameObjectFactory.CreateLight(new LightData() {Ambient = 1f}),
            CreateImagePreview(targetTexture),
            CreateGeneratingImage(targetTexture.Data),
        };
    }

    private GameObject CreateImagePreview(Texture2D targetTexture)
    {
        UnlitMaterial material = new(new LitMaterialData()
        {
            Base = targetTexture
        });
        
        return GameObjectFactory.WithRenderData("Image preview", new RenderData(MeshBuilder.Quad(1f), material)
        {
            Transform = new Transform(new Vector3(1, 0, 0)),
        });
    }

    private GameObject CreateGeneratingImage(Texture2DData textureData)
    {
        RawTextureSource textureSource = new();
        Texture2D texture = new(textureSource);
        Transform transform = new(new Vector3(-1, 0, 0));
        UnlitMaterial material = new(new LitMaterialData()
        {
            Base = texture
        });
        
        return new GameObject(new GameObjectData("Generating image", transform)
        {
            Components = new List<IGameComponent>()
            {
                new GeneratedImageView(textureSource, texture, textureData),
            },
            
            Drawable = new Model(new RenderData(MeshBuilder.Quad(1f), material)
            {
                Transform = transform,
            })
        });
    }
}