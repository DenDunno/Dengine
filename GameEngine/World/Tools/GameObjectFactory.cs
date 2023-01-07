
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

    public static GameObject Sprite(Texture sprite, Transform transform)
    {
        RenderData renderData = new()
        {
            Transform = transform,
            Mesh = MeshBuilder.Quad(1f),
            Material = new UnlitMaterial(new LitMaterialData()
            {
                Base = sprite
            })
        };

        return new GameObject(new GameObjectData("Default name", renderData.Transform)
        {
            Model = new Model(renderData)
        });
    }

    public static GameObject WithRenderData(RenderData renderData, Transform transform)
    {
        renderData.Transform = transform;
        
        return new GameObject(new GameObjectData("Default name", renderData.Transform)
        {
            Model = new Model(renderData)
        });
    }

    public static GameObject Sprite(string sprite, Transform transform)
    {
        return Sprite(new Texture(sprite), transform);
    }

    public static GameObject Sprite(IGameComponent tag, string sprite, Transform transform)
    {
        GameObject gameObject = Sprite(sprite, transform);
        gameObject.Data.Components.Add(tag);
        gameObject.Data.Name = tag.GetType().Name;
        
        return gameObject;
    }

    public static GameObject Point(IGameComponent tag, Transform transform)
    {
        return new GameObject(new GameObjectData(tag.GetType().Name, transform)
        {
            Components = new List<IGameComponent>()
            {
                tag
            }
        });
    }
}