using System.Reflection;

public class Reflection
{
    private readonly World _world;

    public Reflection(World world)
    {
        _world = world;
    }

    public void EnableComponent<T>(string gameObjectName) where T : TogglingComponent
    {
        FindComponent<T>(gameObjectName).Enable();
    }
    
    public void DisableComponent<T>(string gameObjectName) where T : TogglingComponent
    {
        FindComponent<T>(gameObjectName).Disable();
    }

    private TogglingComponent FindComponent<T>(string gameObjectName) where T : TogglingComponent
    {
        List<GameObject> gameObjects = (List<GameObject>)GetField<IReadOnlyCollection<GameObject>, World>(_world);
        GameObjectData data = FindGameObject(gameObjectName, gameObjects);
        return FindComponent<T>(data);
    }

    private T GetField<T, TU>(TU instance)
    {
        FieldInfo[] fieldInfos = instance!.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (FieldInfo fieldInfo in fieldInfos)
        {
            if (fieldInfo.FieldType == typeof(T))
            {
                return (T)fieldInfo.GetValue(instance)!;
            }
        }

        return default!;
    }

    private GameObjectData FindGameObject(string gameObjectName, List<GameObject> gameObjects)
    {
        foreach (GameObject gameObject in gameObjects)
        {
            GameObjectData data = GetField<GameObjectData, GameObject>(gameObject);

            if (data.Name == gameObjectName)
            {
                return data;
            }
        }

        return null!;
    }

    private TogglingComponent FindComponent<T>(GameObjectData data) where T : TogglingComponent
    {
        foreach (IUpdatable updatable in data.Components)
        {
            if (updatable is T component)
            {
                return component;
            }
        }

        return default!;
    }
}