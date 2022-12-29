using System.Reflection;

public abstract class FieldSerialization<T> : IFieldSerialization
{
    public void Serialize(FieldInfo fieldInfo, object value, object instance)
    {
        object newValue = OnSerialize(fieldInfo.Name, (T)value);

        if (value != newValue)
        {
            fieldInfo.SetValue(instance, newValue);
        }
    }

    protected abstract object OnSerialize(string fieldInfoName, T texture);
}