using System.Reflection;

public interface IFieldSerialization
{
    public void Serialize(FieldInfo fieldInfo, object value, object instance);
}