using System.Drawing;
using System.Reflection;
using OpenTK.Mathematics;

public class DataSerialization
{
    private readonly EnumSerialization _enumSerialization = new();
    private readonly Dictionary<Type, IFieldSerialization> _typeSerialization;
    private readonly BindingFlags _bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public;

    public DataSerialization()
    {
        _typeSerialization = new Dictionary<Type, IFieldSerialization>()
        {
            {typeof(float), new FloatSerialization()},
            {typeof(Color), new ColorSerialization()},
            {typeof(bool), new BooleanSerialization()},
            {typeof(Vector3), new Vector3Serialization()},
            {typeof(Texture), new TextureSerialization()},
            {typeof(int), new IntSerialization()},
        };
    }

    public void Execute(IGameComponent gameComponent)
    {
        foreach (FieldInfo fieldInfo in gameComponent.GetType().GetFields(_bindingFlags))
        {
            Execute(fieldInfo, gameComponent);
        }
    }

    private void Execute(FieldInfo fieldInfo, object instance)
    {
        object field = fieldInfo.GetValue(instance)!;

        if (fieldInfo.IsDefined(typeof(EditorField), false))
        {
            TrySerializeChildren(field);
            TrySerializeYourself(fieldInfo, field, instance);    
        }
    }

    private void TrySerializeChildren(object? field)
    {
        if (field != null)
        {
            FieldInfo[] childFieldInfos = field.GetType().GetFields(_bindingFlags);

            foreach (FieldInfo childFieldInfo in childFieldInfos)
            {
                if (childFieldInfo.IsDefined(typeof(EditorField), false))
                {
                    Execute(childFieldInfo, field);
                }
            }
        }
    }

    private void TrySerializeYourself(FieldInfo fieldInfo, object field, object instance)
    {
        _typeSerialization.TryGetValue(fieldInfo.FieldType, out IFieldSerialization? serialization);
        
        if (fieldInfo.FieldType.IsEnum)
        {
            serialization = _enumSerialization;
        }
        
        serialization?.Serialize(fieldInfo, field, instance);
    }
}