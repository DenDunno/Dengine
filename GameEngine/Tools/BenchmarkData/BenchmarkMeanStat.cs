
public struct BenchmarkMeanStat
{
    private float _value;
    private int _count;

    public float Value
    {
        get
        {
            float mean = _value / _count;
            Reset();
            
            return mean;
        }
    }

    public void AddDelta(float delta)
    {
        SetValue(_value + delta, _count + 1);
    }

    private void Reset()
    {
        SetValue(0, 0);
    }

    private void SetValue(float value, int count)
    {
        _value = value;
        _count = count;
    }
}