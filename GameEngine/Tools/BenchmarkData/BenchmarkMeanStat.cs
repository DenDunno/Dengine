﻿
public class BenchmarkMeanStat
{
    public readonly string Name;
    private double _value;
    private int _count;

    public BenchmarkMeanStat(string name)
    {
        Name = name;
        _count = 0;
        _value = 0;
    }

    public double Value => _value / _count;

    public void AddDelta(double delta)
    {
        SetValue(_value + delta, _count + 1);
    }

    public void Reset()
    {
        SetValue(0, 0);
    }

    private void SetValue(double value, int count)
    {
        _value = value;
        _count = count;
    }
}