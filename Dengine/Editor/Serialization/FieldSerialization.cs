using System.Reflection;

public abstract class FieldSerialization<T> : IFieldSerialization
{
    public void Serialize(FieldInfo fieldInfo, object value, object instance)
    {
        string displayName = GetDisplayFieldName(fieldInfo.Name);
        object newValue = OnSerialize(displayName, (T)value);

        if (value != newValue)
        {
            fieldInfo.SetValue(instance, newValue);
        }
    }

    private string GetDisplayFieldName(string fieldName)
    {
        string result = fieldName;
        
        if (fieldName[0] == '_')
        {
            char[] charArray = fieldName.ToCharArray();
            charArray[1] = char.ToUpper(charArray[1]);
            result = new string(charArray, 1, charArray.Length - 1);
        }

        return result;
    }

    protected abstract object OnSerialize(string fieldInfoName, T texture);
}