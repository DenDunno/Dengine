using System.Reflection;

public static class TypeExtensions
{
    public static List<FieldInfo> GetAllFields(this Type type, BindingFlags bindingFlags)
    {
        List<FieldInfo> result = new();
        
        AddFields(type, result, bindingFlags);
        
        return result;
    }

    private static void AddFields(Type type, List<FieldInfo> result, BindingFlags bindingFlags)
    {
        if (type.BaseType != typeof(object))
        {
            AddFields(type.BaseType!, result, bindingFlags);
        }

        result.AddRange(type.GetFields(bindingFlags));
    }
}