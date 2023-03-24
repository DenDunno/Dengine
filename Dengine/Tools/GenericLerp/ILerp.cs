
interface ILerp<T> : ILerpWrapper
{
    T Evaluate(T first, T second, float lerp);
}