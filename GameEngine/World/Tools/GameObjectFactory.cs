namespace Pacman;

public static class GameObjectFactory
{
    public static GameObject Point(IGameComponent tag)
    {
        return new GameObject(new GameObjectData(tag.GetType().Name, new Transform())
        {
            Components = new List<IGameComponent>()
            {
                tag
            }
        });
    }
    
    public static GameObject Sprite(IGameComponent tag, string sprite)
    {
        RenderData renderData = new()
        {
            Mesh = MeshBuilder.Quad(1f),
            Material = new UnlitMaterial(new LitMaterialData()
            {
                Base = new Texture(Paths.GetTexture(sprite))
            })
        };

        return new GameObject(new GameObjectData(tag.GetType().Name, renderData.Transform)
        {
            Components = new List<IGameComponent>()
            {
                tag
            },
           
            Model = new Model(renderData)
        });
    }
}