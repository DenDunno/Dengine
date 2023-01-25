
class FloatLerp : ILerp<float>
{
    public float Evaluate(float first, float second, float lerp)
    {
        if (first > second)
        {
            Algorithms.Swap(ref first, ref second);
            lerp = 1 - lerp;
        }
        
        return Algorithms.Lerp(first, second, lerp);
    }
}