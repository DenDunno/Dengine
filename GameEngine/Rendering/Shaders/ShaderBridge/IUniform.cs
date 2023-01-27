

public interface IUniform<in T> : IUniformWrapper
{
    void SetValue(int id, T value);
}